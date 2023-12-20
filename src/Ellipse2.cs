using System;
using System.Runtime.CompilerServices;
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

        public LineSegment2 MajorAxis() {
            return new LineSegment2(this[Angle.FromRadians(0d)], this[Angle.FromDegrees(180)]);
        }

        public LineSegment2 MinorAxis() {
            return new LineSegment2(this[Angle.FromDegrees(90)], this[Angle.FromDegrees(270)]);
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

        internal void ToSvg(XmlNode parent, string fillColor) {
            var doc = parent.OwnerDocument;
            var element = doc.CreateElement("ellipse");
            element.SetAttribute("fill", fillColor);
            element.SetAttribute("rx", MajorRadius.ToString());
            element.SetAttribute("ry", MinorRadius.ToString());
            if (Angle.Radians != 0d) {
                element.SetAttribute("cx", "0");
                element.SetAttribute("cy", "0");
                element.SetAttribute("transform", transformation.ToSvgTransform());
            } else {
                element.SetAttribute("cx", Origin.X.ToString());
                element.SetAttribute("cy", Origin.Y.ToString());
            }
            parent.AppendChild(element);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Ellipse2;
            if (other != null) {
                var comparer = DoubleComparer.Instance;
                return Origin.Equals(other.Origin) && comparer.Equals(MajorRadius, other.MajorRadius) && comparer.Equals(MinorRadius, other.MinorRadius) && Angle.Equals(other.Angle);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }
        
        public override string ToString()
        {
            return $"Ellipse2(Radii={MajorRadius}x{MinorRadius} {Origin} {Angle})";
        }
    }
}