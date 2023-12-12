
using System;

namespace Intersect {

    public static class IntersectionOfEllipseWithLine
    {
        public static Point2[] Intersect(Ellipse2 ellipse, Line2 line) {
            var a2 = ellipse.MajorRadius * ellipse.MajorRadius;
            var b2 = ellipse.MinorRadius * ellipse.MinorRadius;
            var theta = ellipse.Angle.Radians;
            var sinTheta = Math.Sin(theta);
            var cosTheta = Math.Cos(theta);
            var xOrigin = ellipse.Origin.X;
            var yOrigin = ellipse.Origin.Y;
            // From: https://en.wikipedia.org/wiki/Ellipse#General_ellipse
            double a = a2 * sinTheta * sinTheta + b2 * cosTheta * cosTheta;
            double b = 2d * (b2 - a2) * sinTheta * cosTheta;
            double c = a2 * cosTheta * cosTheta + b2 * sinTheta * sinTheta;
            double d = -2d * a * xOrigin - b * yOrigin;
            double e = -b * xOrigin - 2d * c * yOrigin;
            double f = a * xOrigin * xOrigin + b * xOrigin * yOrigin + c * yOrigin * yOrigin - a2 * b2;
            var l = line.Intercept;
            var m = line.Slope;
            // Fill in y = m * x + l and putting into normal form, gives:
            var solutions = 
                EquationSolver.SolveQuadratic(
                    a + b * m + c * m * m,
                    b * l + 2d * c * m * l + d + e * m,
                    c * l * l + e * l + f
                    );
            Point2[] points = new Point2[solutions.Count];
            for (int i = 0; i < points.Length; i++) {
                points[i] = line[solutions[i]];
            }
            return points;
        }
    }
}