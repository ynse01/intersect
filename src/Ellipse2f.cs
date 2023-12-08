using System;

namespace Intersect {

    public class Ellipse2f
    {
        public Point2f Origin;

        public Vector2f Direction;

        public float MajorRadius;

        public float MinorRadius;

        public float Area() {
            return (float)(Math.PI * MajorRadius * MinorRadius);
        }
    }
}