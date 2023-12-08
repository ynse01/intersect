using System;
using NUnit.Framework;

namespace Intersect.Test {

    public class IntersectionOfEllipseWithLineTests
    {
        [Test]
        public void TestIntersectionSimpleEllipse()
        {
            // Arrange
            var ellipse = new Ellipse2f() {
                MajorRadius = 18,
                MinorRadius = 14
            };
            var line = new Line2f {
                Slope = 1,
                Intercept = 0
            };
            var val = 11.050932f;
            var expected = new Point2f[] { 
                new Point2f { X = -val, Y = -val},
                new Point2f { X = val, Y = val}
            };
            // Act
            var actual = IntersectionOfEllipseWithLine.Intersect(ellipse, line);
            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}