using NUnit.Framework;

namespace Intersect.Test {

    public class SvgExportTests
    {
        [Test]
        public void TestEllipse()
        {
            // Arrange
            var center = new Point2(50d, 50d);
            var angle = Angle.FromDegrees(30);
            var ellipse = new Ellipse2(48, 24, center, angle);
            var majorLine = ellipse.MajorAxis();
            var minorLine = ellipse.MinorAxis();
            var svg = new SvgExport(100, 100);
            // Act
            svg.Draw(ellipse, "red");
            svg.Draw(majorLine, "blue");
            svg.Draw(minorLine, "blue");
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
            var angle = Angle.FromDegrees(30d);
            var error = Angle.FromDegrees(5);
            var ellipse = new Ellipse2(48, 24, center, angle);
            var majorLine = ellipse.MajorAxis();
            var minorLine = ellipse.MinorAxis();
            var svg = new SvgExport(100, 100);
            // Act
            svg.Draw(ellipse, "blue");
            var polyLine = ellipse.ToPolyLine(error);
            svg.Draw(polyLine, "green");
            svg.Draw(majorLine, "red");
            svg.Draw(minorLine, "red");
            // Assert
            svg.WriteToFile("testoverlap.svg");
        }
    }
}