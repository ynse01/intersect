using System;
using NUnit.Framework;

namespace Intersect.Test {

    public class Ellipse2Tests
    {
        [Test]
        public void TestArea()
        {
            // Arrange
            var center = new Point2(3d, 6d);
            var angle = Angle.FromDegrees(0d);
            var ellipse = new Ellipse2(18, 14, center, angle);
            var expected = Math.PI * 18 * 14;
            // Act
            var actual = ellipse.Area();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}