using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Intersect {

    public class PolyLine2
    {
        public List<Point2> Points = new List<Point2>();

        public int SegmentCount() {
            return Math.Max(0, Points.Count - 1);
        }

        public void Close() {
            Points.Add(Points[0]);
        }

        internal void ToSvg(XmlNode parent, string strokeColor) {
            var doc = parent.OwnerDocument;
            var element = doc.CreateElement("polyline");
            element.SetAttribute("fill", "none");
            element.SetAttribute("stroke", strokeColor);
            StringBuilder builder = new StringBuilder();
            foreach(var point in Points) {
                builder.Append($"{point.X},{point.Y} ");
            }
            builder.Length = builder.Length - 1;
            element.SetAttribute("points", builder.ToString());
            parent.AppendChild(element);
        }

    }
}