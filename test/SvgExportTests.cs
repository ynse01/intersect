using NUnit.Framework;

namespace Intersect.Test {

    public class SvgExportTests
    {
        [Test]
        public void TestEllipse()
        {
            // Arrange
            var center = new Point2(50d, 50d);
            var angle = Angle.FromRadians(0d);
            var ellipse = new Ellipse2(48, 24, center, angle);
            var svg = new SvgExport(100, 100);
            // Act
            svg.Draw(ellipse, "red");
            // Assert
            svg.WriteToFile("testellipse.svg");
        }

        [Test]
        public void TestPolyLine()
        {
            // Arrange
            var polyLine = new PolyLine2();
            polyLine.Points.Add(new Point2(0, 100));
            polyLine.Points.Add(new Point2(50, 25));
            polyLine.Points.Add(new Point2(50, 75));
            polyLine.Points.Add(new Point2(100, 0));
            var svg = new SvgExport(100, 100);
            // Act
            svg.Draw(polyLine, "red");
            // Assert
            svg.WriteToFile("testpolyline.svg");
        }

        [Test]
        public void TestEllipsePolyLineOverlap()
        {
            // Arrange
            var center = new Point2(50d, 50d);
            var angle = Angle.FromRadians(0d);
            var error = Angle.FromDegrees(5);
            var ellipse = new Ellipse2(48, 24, center, angle);
            var svg = new SvgExport(100, 100);
            // Act
            svg.Draw(ellipse, "blue");
            var polyLine = ellipse.ToPolyLine(error);
            svg.Draw(polyLine, "red");
            // Assert
            svg.WriteToFile("testoverlap.svg");
        }
    }
}