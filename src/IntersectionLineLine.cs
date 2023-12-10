
using System;

namespace Intersect {

    public static class IntersectionOfLineWithLine
    {
        public static Point2? Intersect(Line2 left, Line2 right) {
            var ab = left.Slope - right.Slope;
            var dc = right.Intercept - left.Intercept;
            if (ab != 0f) {
                return left[dc / ab];
            }
            return null;
        }
    }
}