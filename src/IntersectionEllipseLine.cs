
using System;

namespace Intersect {

    public static class IntersectionOfEllipseWithLine
    {
        public static Point2f[] Intersect(Ellipse2f ellipse, Line2f line) {
            var a2 = ellipse.MajorRadius * ellipse.MajorRadius;
            var b2 = ellipse.MinorRadius * ellipse.MinorRadius;
            var transformedLine = Transform(line, ellipse.Origin, ellipse.Direction);
            var c = transformedLine.Intercept;
            var m = transformedLine.Slope;
            // See: https://www.emathzone.com/tutorials/geometry/intersection-of-line-and-ellipse.html
            var solutions = EquationSolver.SolveQuadratic(a2 * m * m + b2, 2 * a2 * m * c, a2 * (c * c - b2));
            Point2f[] points = new Point2f[solutions.Count];
            for (int i = 0; i < points.Length; i++) {
                points[i] = transformedLine[solutions[i]];
            }
            return points;
        }

        private static Line2f Transform(Line2f line, Point2f origin, Vector2f direction) {
            // TODO: Implement
            return line;
        }
    }
}