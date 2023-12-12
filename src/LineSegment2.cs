using System;

namespace Intersect {

    public class LineSegment2
    {
        public Point2 Start;

        public Point2 End;

        public Point2 this[double index]
        {
            get
            {
                if (!IsOnSegment(index)) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return Line()[index];
            }
        }

        public double Length() {
            return (End - Start).Length();
        }

        public double SquaredLength() {
            return (End - Start).SquaredLength();
        }

        public Line2 Line() {
            return Line2.FromPoints(Start, End);
        }

        public bool IsOnSegment(double index) {
            return index >= 0d && index <= 1d;
        }
    }
}