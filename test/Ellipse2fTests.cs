using System;
using NUnit.Framework;

namespace Intersect.Test {

    public class Ellipse2fTests
    {
        [Test]
        public void TestArea()
        {
            // Arrange
            var ellipse = new Ellipse2f() {
                MajorRadius = 18,
                MinorRadius = 14,
                Origin = new Point2f { X = 3f, Y = 6f},
                Direction = new Vector2f { X = 1.0f }
            };
            var expected = (float)(Math.PI * 18 * 14);
            // Act
            var actual = ellipse.Area();
            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}