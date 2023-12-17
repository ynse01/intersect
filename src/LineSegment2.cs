using System;
using System.Xml;

namespace Intersect {

    public class LineSegment2
    {
        public Point2 Start;

        public Point2 End;

        public LineSegment2(Point2 start, Point2 end) {
            Start = start;
            End = end;
        }

        public Point2 this[double index]
        {
            get
            {
                if (!IsOnSegment(index)) {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return Line()[index];
            }
        }

        public double Length() {
            return (End - Start).Length();
        }

        public double SquaredLength() {
            return (End - Start).SquaredLength();
        }

        public Line2 Line() {
            return Line2.FromPoints(Start, End);
        }

        public bool IsOnSegment(double index) {
            return index >= 0d && index <= 1d;
        }

        internal void ToSvg(XmlNode parent, string strokeColor) {
            var doc = parent.OwnerDocument;
            var element = doc.CreateElement("line");
            element.SetAttribute("fill", "none");
            element.SetAttribute("stroke", strokeColor);
            element.SetAttribute("x1", Start.X.ToString());
            element.SetAttribute("y1", Start.Y.ToString());
            element.SetAttribute("x2", End.X.ToString());
            element.SetAttribute("y2", End.Y.ToString());
            parent.AppendChild(element);
        }

    }
}