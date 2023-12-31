using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public struct Vector3
    {
        public double X;

        public double Y;

        public double Z;

        public Vector3(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }

        public double SquaredLength() {
            return Dot(this);
        }

        public double Length() {
            return Math.Sqrt(Dot(this));
        }

        public double Dot(Vector3 other) {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        public Vector3 Cross(Vector3 other) {
            var cross = new Vector3 {
                X = Y * other.Z - Z * other.Y,
                Y = X * other.Z - Z * other.X,
                Z = X * other.Y - Y * other.X
            };
            return cross;
        }

        public void Normalize() {
            var length = Length();
            X /= length;
            Y /= length;
            Z /= length;
        }

        public static Vector3 operator +(Vector3 left, Vector3 right) {
            return new Vector3() { 
                X = left.X + right.X,
                Y = left.Y + right.Y,
                Z = left.Z + right.Z
            };
        }

        public static Vector3 operator -(Vector3 left, Vector3 right) {
            return new Vector3() { 
                X = left.X - right.X,
                Y = left.Y - right.Y,
                Z = left.Z - right.Z
            };
        }

        public static Vector3 operator *(Vector3 vector, double scalar) {
            return new Vector3() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar,
                Z = vector.Z * scalar
            };
        }

        public static Vector3 operator *(double scalar, Vector3 vector) {
            return new Vector3() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar,
                Z = vector.Z * scalar
            };
        }

        internal Matrix ToMatrix() {
            var matrix = new Matrix(1, 3);
            matrix[0, 0] = X;
            matrix[0, 1] = Y;
            matrix[0, 2] = Z;
            return matrix;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3) {
                var other = (Vector3)obj;
                var comparer = DoubleComparer.Instance;
                return comparer.Equals(X, other.X) && comparer.Equals(Y, other.Y) && comparer.Equals(Z, other.Z);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"Vector3({X}, {Y}, {Z})";
        }
    }
}