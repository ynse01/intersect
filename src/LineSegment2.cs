using System;

namespace Intersect {

    public class LineSegment2
    {
        public Line2 Line;

        public double StartIndex;

        public double EndIndex;

        public Point2 this[double index]
        {
            get
            {
                if (!IsOnSegment(index)) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return Line[index];
            }
        }

        public double Length() {
            return (this[EndIndex] - this[StartIndex]).Length();
        }

        public double SquaredLength() {
            return (this[EndIndex] - this[StartIndex]).SquaredLength();
        }

        public bool IsOnSegment(double index) {
            return index >= StartIndex && index <= EndIndex;
        }
    }
}