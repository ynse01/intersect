using System.Collections.Generic;
using NUnit.Framework;

namespace Intersect.Test {

    public class IntersectionOfCylinderWithPlaneTests
    {
        [Test]
        public void TestIntersectionParallel()
        {
            // Arrange
            var cylinder = new Cylinder3(new Point3(), new Vector3(0, 0, 1), 24, 5);
            var plane = new Plane3(new Point3(), new Vector3(0, 1, 0));
            IReadOnlyList<LineSegment3> expected = new List<LineSegment3> { 
                new LineSegment3(new Point3(5, 0, -12), new Point3(5, 0, 12)),
                new LineSegment3(new Point3(-5, 0, -12), new Point3(-5, 0, 12))
            };
            // Act
            cylinder.Intersect(plane, out var ellipse, out var actual);
            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
            Assert.IsNull(ellipse);
        }
    }
}