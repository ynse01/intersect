using System;
using NUnit.Framework;

namespace Intersect.Test {

    public class Line2Tests
    {
        [Test]
        [TestCase(0, 0, 1, 1, 1, 0)]
        [TestCase(0, 0, 5, 1, 1d/5d, 0)]
        [TestCase(0, 0, 1, 5, 5, 0)]
        [TestCase(1, 1, 2, 2, 1, 0)]
        [TestCase(2, 2, 3, 3, 1, 0)]
        [TestCase(2, 0, 3, 1, 1, -2)]
        [TestCase(2, 0, 4, 2, 1, -2)]
        public void TestFromPoints(double x1, double y1, double x2, double y2, double slope, double intercept)
        {
            // Arrange
            var start = new Point2 { X = x1, Y = y1 };
            var end = new Point2 { X = x2, Y = y2 };
            var expected = new Line2(slope, intercept);
            // Act
            var actual = Line2.FromPoints(start,end);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}