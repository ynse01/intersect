using System;
using System.Collections.Generic;

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
    }
}