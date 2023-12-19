using System;
using NUnit.Framework;

namespace Intersect.Test {

    public class CartesianSpaceTests
    {
        [Test]
        public void TestOrthogonality()
        {
            // Arrange
            var center = new Point3(3, 6, 5);
            var normal = new Vector3(0, 0, 1);
            var expected = 0d;
            // Act
            var actual = CartesianSpace.FromNormal(center, normal);
            // Assert
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual.XAxis.Dot(actual.YAxis));
            Assert.AreEqual(expected, actual.YAxis.Dot(actual.ZAxis()));
            Assert.AreEqual(expected, actual.ZAxis().Dot(actual.XAxis));
        }
    }
}