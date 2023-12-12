using System;
using NUnit.Framework;

namespace Intersect.Test {

    public class IntersectionOfEllipseWithLineTests
    {
        [Test]
        public void TestIntersectionSimpleEllipse()
        {
            // Arrange
            var ellipse = new Ellipse2(18, 14);
            var line = new Line2(1d, 0d);
            var val = 11.050932f;
            var expected = new Point2[] { 
                new Point2(-val, -val),
                new Point2(val, val)
            };
            // Act
            var actual = IntersectionOfEllipseWithLine.Intersect(ellipse, line);
            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}