using System.Collections.Generic;

namespace Intersect {

    public static class Extensions
    {
        public static void Intersect(this Cylinder3 cylinder, Plane3 plane, out Ellipse2 ellipse, out IReadOnlyList<LineSegment3> lines) {
            IntersectionOfCylinderWithPlane.Intersect(cylinder, plane, out ellipse, out lines);
        }

        public static Point2[] Intersect(this Ellipse2 ellipse, Line2 line) {
            return IntersectionOfEllipseWithLine.Intersect(ellipse, line);
        }

        public static Point2[] Intersect(this Line2 line, Ellipse2 ellipse) {
            return IntersectionOfEllipseWithLine.Intersect(ellipse, line);
        }

        public static Point2? Intersect(this Line2 left, Line2 right) {
            return IntersectionOfLineWithLine.Intersect(left, right);
        }
    }
}