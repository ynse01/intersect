using System.Collections.Generic;

namespace Intersect {

    public class Polygon2
    {
        public List<PolyLine2> Contours = new List<PolyLine2>();

        public int ContourCount() {
            return Contours.Count;
        }

        public void MoveTo(Point2 point) {
            var polyline = new PolyLine2();
            polyline.Points.Add(point);
            Contours.Add(polyline);
        }

        public void LineTo(Point2 point) {
            Contours[Contours.Count - 1].Points.Add(point);
        }

        public void Close() {
            var lastContour = Contours[Contours.Count - 1];
            lastContour.Close();
        }
    }
}