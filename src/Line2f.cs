using System;
using System.Drawing;

namespace Intersect {

    public class Line2f
    {
        public float Intercept;

        public float Slope;

        public Point2f this[float x] {
            get {
                return new Point2f { X = x, Y = Slope * x + Intercept };
            }
        }

        public Point2f Origin() {
            return new Point2f { X = 0.0f, Y = Intercept };
        }

        public Vector2f Direction() {
            var direction = new Vector2f { X = 1, Y = Slope };
            direction.Normalize();
            return direction;
        }

        public float Project(Point2f point) {
            var vector = point - Origin();
            return Direction().Dot(vector);
        }

        public Point2f Symmetric(Point2f point) {
            var projected = this[Project(point)];
            return point + 2 * (point - projected);
        }
    }
}