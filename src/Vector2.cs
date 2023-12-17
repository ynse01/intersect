using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public struct Vector2
    {
        public double X;

        public double Y;

        public Vector2(double x, double y) {
            X = x;
            Y = y;
        }

        public double SquaredLength() {
            return Dot(this);
        }

        public double Length() {
            return Math.Sqrt(Dot(this));
        }

        public double Dot(Vector2 other) {
            return X * other.X + Y * other.Y;
        }

        public double Cross(Vector2 other) {
            return X * other.Y - Y * other.X;
        }

        public void Normalize() {
            var length = Length();
            X /= length;
            Y /= length;
        }

        public Angle Angle() {
            return Intersect.Angle.FromRadians(Math.Atan(Y / X));
        }

        public static Vector2 operator +(Vector2 left, Vector2 right) {
            return new Vector2() { 
                X = left.X + right.X,
                Y = left.Y + right.Y
            };
        }

        public static Vector2 operator -(Vector2 left, Vector2 right) {
            return new Vector2() { 
                X = left.X - right.X,
                Y = left.Y - right.Y
            };
        }

        public static Vector2 operator *(Vector2 vector, double scalar) {
            return new Vector2() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar
            };
        }

        public static Vector2 operator *(double scalar, Vector2 vector) {
            return new Vector2() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2) {
                var other = (Vector2)obj;
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
            return $"Vector2({X}, {Y})";
        }
    }
}