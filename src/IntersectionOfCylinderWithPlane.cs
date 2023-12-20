using System;
using System.Collections.Generic;

namespace Intersect {

    internal static class IntersectionOfCylinderWithPlane
    {
        public static void Intersect(Cylinder3 cylinder, Plane3 plane, out Ellipse2 ellipse, out IReadOnlyList<LineSegment3> lines) {
            // Taken over from: https://www.geometrictools.com/Documentation/IntersectionCylinderPlane.pdf
            var space = plane.Space();
            ellipse = IntersectThrough(cylinder, space);
            if (ellipse == null) {
                lines = IntersectParallel(cylinder, space);
            } else {
                lines = new List<LineSegment3>();
            }
        }

        private static List<LineSegment3> IntersectParallel(Cylinder3 cylinder, CartesianSpace space) {
            var lines = new List<LineSegment3>();
            var delta = cylinder.Origin - space.Origin;
            var n = space.ZAxis();
            var scaledNormal = n.Dot(delta) * n;
            var d = n.Dot(delta);
            var r2 = cylinder.Radius * cylinder.Radius;
            var d2 = d * d;
            if (r2 > d2) {
                // TODO: Compensate for length of line change with angle of ingtersection.
                var halfHeight = cylinder.Height / 2d;
                var l = Math.Sqrt(cylinder.Radius * cylinder.Radius - d * d);
                var postfix = l * n.Cross(cylinder.Axis);
                var k0 = cylinder.Origin - scaledNormal + postfix;
                var line0 = new Line3(k0, cylinder.Axis);
                lines.Add(new LineSegment3(line0[-halfHeight], line0[halfHeight]));
                if (l != 0d) {
                    var k1 = cylinder.Origin - scaledNormal - postfix;
                    var line1 = new Line3(k1, cylinder.Axis);
                    lines.Add(new LineSegment3(line1[-halfHeight], line1[halfHeight]));
                }
            }
            return lines;
        }

        private static Ellipse2 IntersectThrough(Cylinder3 cylinder, CartesianSpace space) {
            var a = space.XAxis.ToMatrix();
            var b = space.YAxis.ToMatrix();
            var at = a.Transposed();
            var bt = b.Transposed();
            var delta = (space.Origin - cylinder.Origin).ToMatrix();
            var w = cylinder.Axis.ToMatrix();
            var m = Matrix.Identity(3) - w * w.Transposed();
            Console.WriteLine($"a {a}, b {b}, M {m}");
            var q0 = (delta.Transposed() * m * delta)[0, 0] - cylinder.Radius * cylinder.Radius;
            var q1 = new Matrix(1, 2);
            q1[0, 0] = 2d * (at * m * delta)[0, 0];
            q1[0, 1] = 2d * (bt * m * delta)[0, 0];
            var q2 = new Matrix(2, 2);
            q2[0, 0] = (at * m * a)[0, 0];
            q2[0, 1] = (at * m * b)[0, 0];
            q2[1, 0] = (at * m * b)[0, 0];
            q2[1, 1] = (bt * m * b)[0, 0];
            var k = -1d * q2.Inversed() * q1;
            var s = q2 / ((k.Transposed() * q2 * k)[0, 0] - q0);
            Console.WriteLine($"S {s}, Q1 {q1}, Q2 {q2}");
            EigenValues2x2(s, out double eig0, out double eig1);
            if (!double.IsNaN(eig0) || !double.IsNaN(eig1)) {
                Console.WriteLine($"Eigen values {eig0} {eig1}");
                var majorRadius = Math.Sqrt(1d / Math.Sqrt(eig0));
                var minorRadius = Math.Sqrt(1d / Math.Sqrt(eig1));
                var direction = EigenValue2EigenVector2x2(s, eig0);
                return new Ellipse2(majorRadius, minorRadius, AsPoint2(k), direction.Angle());
            }
            return null;
        }

        private static void EigenValues2x2(Matrix matrix, out double largest, out double smallest) {
            var m = (matrix[0, 0] + matrix[1, 1]) /2d;
            var p = matrix.Determinant();
            largest = p + Math.Sqrt(m * m - p);
            smallest = p - Math.Sqrt(m * m - p);
        }

        private static Vector2 EigenValue2EigenVector2x2(Matrix matrix, double eigenValue) {
            return new Vector2(matrix[0, 1], eigenValue - matrix[0, 0]);
        }

        private static Point2 AsPoint2(Matrix matrix) {
            return new Point2(matrix[0, 0], matrix[0, 1]);
        }
    }
}