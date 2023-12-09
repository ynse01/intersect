using NUnit.Framework;

namespace Intersect.Test {

    public class EquationSolverTests
    {
        [Test]
        [TestCase(-2, 1)]
        [TestCase(-4, 2)]
        [TestCase(2, 4)]
        [TestCase(2, 1)]
        public void TestLinear(float a, float b)
        {
            // Arrange
            // Act
            var actual = EquationSolver.SolveLinear(a, b);
            // Assert
            var y = a * actual + b;
            Assert.AreEqual(0.0f, y);
        }

        [Test]
        [TestCase(-2, 1, 1, 2)]
        [TestCase(-4, 2, 6, 2)]
        [TestCase(2, 4, 2, 1)]
        [TestCase(2, 1, 9, 0)]
        public void TestQuadratic(float a, float b, float c, int numRoots)
        {
            // Arrange
            // Act
            var actual = EquationSolver.SolveQuadratic(a, b, c);
            // Assert
            Assert.AreEqual(numRoots, actual.Count);
            foreach(var x in actual) {
                var y = a * x * x + b * x + c;
                Assert.AreEqual(0.0f, y);
            }
        }

        [Test]
        [TestCase(1, -3, 3, -1, 1)]
        public void TestQubic(float a, float b, float c, float d, int numRoots)
        {
            // Arrange
            // Act
            var actual = EquationSolver.SolveQubic(a, b, c, d);
            // Assert
            Assert.AreEqual(numRoots, actual.Count);
            foreach(var x in actual) {
                var y = a * x * x * x+ b * x * x + c * x + d;
                Assert.AreEqual(0.0f, y);
            }
        }
    }
}