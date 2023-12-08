using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public struct Vector2f
    {
        public float X;

        public float Y;

        public float SquaredLength() {
            return Dot(this);
        }

        public float Length() {
            return (float)Math.Sqrt(Dot(this));
        }

        public float Dot(Vector2f other) {
            return X * other.X + Y * other.Y;
        }

        public float Cross(Vector2f other) {
            return X * other.Y - Y * other.X;
        }

        public void Normalize() {
            var length = Length();
            X /= length;
            Y /= length;
        }

        public float Theta() {
            return (float)Math.Atan2(Y, X);
        }

        public static Vector2f operator +(Vector2f left, Vector2f right) {
            return new Vector2f() { 
                X = left.X + right.X,
                Y = left.Y + right.Y
            };
        }

        public static Vector2f operator -(Vector2f left, Vector2f right) {
            return new Vector2f() { 
                X = left.X - right.X,
                Y = left.Y - right.Y
            };
        }

        public static Vector2f operator *(Vector2f vector, float scalar) {
            return new Vector2f() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar
            };
        }

        public static Vector2f operator *(float scalar, Vector2f vector) {
            return new Vector2f() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2f) {
                var other = (Vector2f)obj;
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
            return $"Vector2f({X}, {Y})";
        }
    }
}