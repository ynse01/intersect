using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public struct Point2f
    {
        public float X;

        public float Y;

        public float SquaredDistance(Point2f other) {
            return (other - this).SquaredLength();
        }

        public float Distance(Point2f other) {
            return (float)Math.Sqrt(Distance(other));
        }


        public static Vector2f operator -(Point2f left, Point2f right) {
            return new Vector2f() { 
                X = left.X - right.X,
                Y = left.Y - right.Y
            };
        }

        public static Point2f operator +(Point2f point, Vector2f vector) {
            return new Point2f() {
                X = point.X + vector.X,
                Y = point.Y + vector.Y
            };
        }

        public static Point2f operator -(Point2f point, Vector2f vector) {
            return new Point2f() {
                X = point.X - vector.X,
                Y = point.Y - vector.Y
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Point2f) {
                var other = (Point2f)obj;
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"Point2f({X}, {Y})";
        }
    }
}