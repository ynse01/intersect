using System;

namespace Intersect {

    public class CartesianSpace
    {
        public Vector3 XAxis;

        public Vector3 YAxis;

        public Point3 Origin;

        private CartesianSpace() {}

        public static CartesianSpace FromTransformation(Transformation3 trans) {
            if (trans[3, 3] != 1d) {
                throw new ArgumentException("Not a rigid transformation");
            }
            var space = new CartesianSpace();
            space.XAxis.X = trans[0, 0];
            space.XAxis.Y = trans[1, 0];
            space.XAxis.Z = trans[2, 0];

            space.YAxis.X = trans[0, 1];
            space.YAxis.Y = trans[1, 1];
            space.YAxis.Z = trans[2, 1];

            space.Origin.X = trans[0, 3];
            space.Origin.Y = trans[1, 3];
            space.Origin.Z = trans[2, 3];
            return space;
        }

        public static CartesianSpace FromNormal(Point3 origin, Vector3 normal) {
            var d = normal.Dot(origin - new Point3());
            var firstAxis = new Vector3(0, -normal.Z / normal.Y, 1d);
            firstAxis.Normalize();
            if (normal.Y == 0d || firstAxis.Dot(normal) > 0.9d) {
                firstAxis = new Vector3(1d, 0, -normal.X / normal.Z);
                firstAxis.Normalize();
                if (normal.X == 0d || firstAxis.Dot(normal) > 0.9d) {
                    firstAxis = new Vector3(1d, 0, -normal.X / normal.Z);
                    firstAxis.Normalize();
                }
            }
            var secondAxis = firstAxis.Cross(normal);
            // Make sure all 3 axes are truely orthogonal.
            var thirdAxis = secondAxis.Cross(normal);
            return new CartesianSpace() {
                XAxis = thirdAxis,
                YAxis = secondAxis,
                Origin = origin
            };
        }

        public Vector3 ZAxis() {
            return XAxis.Cross(YAxis);
        }

        internal Transformation3 Transformation() {
            var matrix = new Transformation3();
            matrix[0, 0] = XAxis.X;
            matrix[1, 0] = XAxis.Y;
            matrix[2, 0] = XAxis.Z;

            matrix[0, 1] = YAxis.X;
            matrix[1, 1] = YAxis.Y;
            matrix[2, 1] = YAxis.Z;
            var zAxis = ZAxis();
            matrix[0, 2] = zAxis.X;
            matrix[1, 2] = zAxis.Y;
            matrix[2, 2] = zAxis.Z;

            matrix[0, 3] = Origin.X;
            matrix[1, 3] = Origin.Y;
            matrix[2, 3] = Origin.Z;
            matrix[3, 3] = 1d;
            return matrix;
        }

        public override string ToString()
        {
            return $"Cartesian(X={XAxis}, Y={YAxis}, Z={ZAxis()})";
        }
    }
}