using System;

namespace Intersect {

    public class LineSegment2f
    {
        public Line2f Line;

        public float StartIndex;

        public float EndIndex;

        public Point2f this[float index]
        {
            get
            {
                if (!IsOn(index)) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return Line[index];
            }
        }

        public bool IsOn(float index) {
            return index >= StartIndex && index <= EndIndex;
        }
    }
}