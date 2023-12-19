using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public class LineSegment3
    {
        public Point3 Start;

        public Point3 End;

        public LineSegment3(Point3 start, Point3 end) {
            Start = start;
            End = end;
        }

        public Point3 this[double index]
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

        public Line3 Line() {
            return Line3.FromPoints(Start, End);
        }

        public bool IsOnSegment(double index) {
            return index >= 0d && index <= 1d;
        }

        public override bool Equals(object obj)
        {
            if (obj is LineSegment3) {
                var other = (LineSegment3)obj;
                return Start.Equals(other.Start) && End.Equals(other.End);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"LineSegment3({Start} -> {End})";
        }
    }
}