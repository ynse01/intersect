using System;

namespace Intersect {

    public class Ellipse2
    {
        public Point2 Origin;

        public Angle Angle;

        public double MajorRadius;

        public double MinorRadius;

        public Ellipse2(double major, double minor) 
            : this(major, minor, new Point2(), Angle.FromDegrees(0d)) {
        }

        public Ellipse2(double major, double minor, Point2 origin, Angle angle) {
            MajorRadius = major;
            MinorRadius = minor;
            Origin = origin;
            Angle = angle;
        }

        public double Area() {
            return Math.PI * MajorRadius * MinorRadius;
        }
    }
}