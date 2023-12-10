using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public struct Point2
    {
        public double X;

        public double Y;

        public double SquaredDistance(Point2 other) {
            return (other - this).SquaredLength();
        }

        public double Distance(Point2 other) {
            return Math.Sqrt(Distance(other));
        }


        public static Vector2 operator -(Point2 left, Point2 right) {
            return new Vector2() { 
                X = left.X - right.X,
                Y = left.Y - right.Y
            };
        }

        public static Point2 operator +(Point2 point, Vector2 vector) {
            return new Point2() {
                X = point.X + vector.X,
                Y = point.Y + vector.Y
            };
        }

        public static Point2 operator -(Point2 point, Vector2 vector) {
            return new Point2() {
                X = point.X - vector.X,
                Y = point.Y - vector.Y
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Point2) {
                var other = (Point2)obj;
                var comparer = DoubleComparer.Instance;
                return comparer.Equals(X, other.X) && comparer.Equals(Y, other.Y);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"Point2({X}, {Y})";
        }
    }
}