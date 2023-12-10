using System;
using System.Drawing;

namespace Intersect {

    public class Line2
    {
        public double Intercept;

        public double Slope;

        public Point2 this[double x] {
            get {
                return new Point2 { X = x, Y = Slope * x + Intercept };
            }
        }

        public Point2 Origin() {
            return new Point2 { X = 0d, Y = Intercept };
        }

        public Vector2 Direction() {
            var direction = new Vector2 { X = 1d, Y = Slope };
            direction.Normalize();
            return direction;
        }

        public double Project(Point2 point) {
            var vector = point - Origin();
            return Direction().Dot(vector);
        }

        public Point2 Symmetric(Point2 point) {
            var projected = this[Project(point)];
            return point + 2d * (point - projected);
        }
    }
}