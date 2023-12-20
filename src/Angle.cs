using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public struct Angle
    {
        private const double Deg2Rad = Math.PI / 180d;
        private const double Rad2Deg = 180d / Math.PI;

        public static Angle FromDegrees(double degrees) {
            return new Angle(degrees * Deg2Rad);
        }

        public static Angle FromRadians(double radians) {
            return new Angle(radians);
        }

        private Angle(double radians) {
            Radians = radians;
        }

        public double Radians { get; }

        public double Degrees() {
            return Radians * Rad2Deg;
        }

        public static Angle operator+(Angle left, Angle right) {
            return new Angle(left.Radians + right.Radians);
        }

        public static Angle operator-(Angle left, Angle right) {
            return new Angle(left.Radians - right.Radians);
        }

        public static Angle operator*(Angle angle, double scalar) {
            return new Angle(angle.Radians * scalar);
        }

        public static Angle operator/(Angle angle, double scalar) {
            return new Angle(angle.Radians / scalar);
        }

        public static double operator/(Angle left, Angle right) {
            return left.Radians / right.Radians;
        }

         public override bool Equals(object obj)
        {
            if (obj is Angle) {
                var other = (Angle)obj;
                var comparer = DoubleComparer.Instance;
                return comparer.Equals(Radians, other.Radians);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"Angle({Degrees()})";
        }
    }
}