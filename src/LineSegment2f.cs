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
                if (!IsOnSegment(index)) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return Line[index];
            }
        }

        public float Length() {
            return (this[EndIndex] - this[StartIndex]).Length();
        }

        public float SquaredLength() {
            return (this[EndIndex] - this[StartIndex]).SquaredLength();
        }

        public bool IsOnSegment(float index) {
            return index >= StartIndex && index <= EndIndex;
        }
    }
}