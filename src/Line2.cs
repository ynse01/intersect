
using System;
using System.Runtime.CompilerServices;

namespace Intersect {

    public class Line2
    {
        public double YIntercept;

        public double Slope;

        public static Line2 FromPoints(Point2 start, Point2 end) {
            var slope = (end.Y - start.Y) / (end.X - start.X);
            var intercept = (slope * start.X) - start.Y;
            return new Line2(slope, intercept);
        }

        public Line2(double slope, double yIntercept) {
            Slope = slope;
            YIntercept = yIntercept;
        }

        public Point2 this[double x] {
            get {
                return new Point2(x, Slope * x + YIntercept);
            }
        }

        public Point2 Origin() {
            return this[0d];
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
                return Slope == other.Slope && YIntercept == other.YIntercept;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"Line2({Slope} * x {(YIntercept > 0 ? '-' : '+')} {Math.Abs(YIntercept)})";
        }

    }
}