using System;
using System.Xml;

namespace Intersect {

    public class Ellipse2
    {
        public Point2 Origin;

        public Angle Angle;

        public double MajorRadius;

        public double MinorRadius;

        private Transformation2 transformation;

        public Ellipse2(double major, double minor) {
            MajorRadius = major;
            MinorRadius = minor;
            Origin = new Point2();
            Angle = Angle.FromRadians(0d);
            transformation = new Transformation2();
        }

        public Ellipse2(double major, double minor, Point2 origin, Angle angle) {
            MajorRadius = major;
            MinorRadius = minor;
            Origin = origin;
            Angle = angle;
            transformation = Transformation2.FromRotationAndTranslation(angle, new Vector2(origin.X, origin.Y));
        }

        public Point2 this[Angle angle] {
            get {
                var x = MajorRadius * Math.Cos(angle.Radians);
                var y = MinorRadius * Math.Sin(angle.Radians);
                return transformation.Transform(new Point2(x, y));
            }
        }

        public double Area() {
            return Math.PI * MajorRadius * MinorRadius;
        }

        public bool LiesOnEdge(Point2 point) {
            var diff = Origin - point;
            if (Angle.Radians != 0d) {
                diff = transformation.Transform(diff);
            }
            var value = diff.X * diff.X / ( MajorRadius * MajorRadius) + diff.Y * diff.Y / (MinorRadius * MinorRadius);
            return DoubleComparer.Instance.Compare(value, 1d) == 0;
        }

        public PolyLine2 ToPolyLine(Angle maxError) {
            return ToPolyLine(maxError, Angle.FromDegrees(0d), Angle.FromDegrees(360d));
        }

        public PolyLine2 ToPolyLine(Angle maxError, Angle start, Angle end) {
            var result = new PolyLine2();
            var lineCount = Math.Ceiling((end - start) / maxError);
            var increment = (end - start) / lineCount;
            result.Points.Add(this[start]);
            for(int i = 1; i < lineCount - 1; i++) {
                result.Points.Add(this[increment * i]);
            }
            result.Points.Add(this[end]);
            return result;
        }
    }
}