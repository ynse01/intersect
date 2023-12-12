using System;
using NUnit.Framework;

namespace Intersect.Test {

    public class Ellipse2Tests
    {
        [Test]
        public void TestArea()
        {
            // Arrange
            var ellipse = new Ellipse2() {
                MajorRadius = 18,
                MinorRadius = 14,
                Origin = new Point2 { X = 3d, Y = 6d},
                Angle = Angle.FromDegrees(0d)
            };
            var expected = Math.PI * 18 * 14;
            // Act
            var actual = ellipse.Area();
            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}