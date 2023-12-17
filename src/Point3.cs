using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public struct Point3
    {
        public double X;

        public double Y;

        public double Z;

        public Point3(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }

        public double SquaredDistance(Point3 other) {
            return (other - this).SquaredLength();
        }

        public double Distance(Point3 other) {
            return Math.Sqrt(Distance(other));
        }


        public static Vector3 operator -(Point3 left, Point3 right) {
            return new Vector3() { 
                X = left.X - right.X,
                Y = left.Y - right.Y,
                Z = left.Z - right.Z
            };
        }

        public static Point3 operator +(Point3 point, Vector3 vector) {
            return new Point3() {
                X = point.X + vector.X,
                Y = point.Y + vector.Y,
                Z = point.Z + vector.Z
            };
        }

        public static Point3 operator -(Point3 point, Vector3 vector) {
            return new Point3() {
                X = point.X - vector.X,
                Y = point.Y - vector.Y,
                Z = point.Z - vector.Z
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3) {
                var other = (Point3)obj;
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
            return $"Point3({X}, {Y}, {Z})";
        }
    }
}