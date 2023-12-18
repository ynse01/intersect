
namespace Intersect {

    internal static class IntersectionOfLineWithLine
    {
        public static Point2? Intersect(Line2 left, Line2 right) {
            var index = GetIntersectionIndex(left, right);
            if (index.HasValue) {
                return left[index.Value];
            }
            return null;
        }

        public static Point2? Intersect(LineSegment2 left, LineSegment2 right) {
            var index = GetIntersectionIndex(left.Line(), right.Line());
            if (index.HasValue && left.IsOnSegment(index.Value)) {
                return left[index.Value];
            }
            return null;
        }

        private static double? GetIntersectionIndex(Line2 left, Line2 right) {
            var ab = left.Slope - right.Slope;
            var dc = -right.YIntercept + left.YIntercept;
            if (ab != 0f) {
                return dc / ab;
            }
            return null;

        }
    }
}