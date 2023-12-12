
using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public class Line2
    {
        public double Intercept;

        public double Slope;

        public static Line2 FromPoints(Point2 start, Point2 end) {
            var slope = (end.Y - start.Y) / (end.X - start.X);
            var intercept = start.Y - (slope * start.X);
            return new Line2(slope, intercept);
        }

        public Line2(double slope, double intercept) {
            Slope = slope;
            Intercept = intercept;
        }

        public Point2 this[double x] {
            get {
                return new Point2(x, Slope * x + Intercept);
            }
        }

        public Point2 Origin() {
            return new Point2(0d, Intercept);
        }

        public Vector2 Direction() {
            var direction = new Vector2(1d, Slope);
            direction.Normalize();
            return direction;
        }

        public Angle Angle() {
            return new Vector2(1d, Slope).Angle();
        }

        public double Project(Point2 point) {
            var vector = point - Origin();
            return Direction().Dot(vector);
        }

        public Point2 Symmetric(Point2 point) {
            var projected = this[Project(point)];
            return point + 2d * (point - projected);
        }

        public override bool Equals(object obj)
        {
            if (obj is Line2) {
                var other = (Line2)obj;
                return Slope == other.Slope && Intercept == other.Intercept;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"Line2({Slope} * x {(Intercept < 0 ? '-' : '+')} {Math.Abs(Intercept)})";
        }

    }
}