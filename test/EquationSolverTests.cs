using NUnit.Framework;

namespace Intersect.Test {

    public class EquationSolverTests
    {
        [Test]
        [TestCase(-2, 1, 1, 1, -0.5f)]
        [TestCase(-4, 2, 6, -1, 1.5f)]
        public void TestQuadratic2Roots(float a, float b, float c, float root0, float root1)
        {
            // Arrange
            float[] expected = new float[] { root0, root1};
            // Act
            var actual = EquationSolver.SolveQuadratic(a, b, c);
            // Assert
            CollectionAssert.AreEquivalent(actual, expected);
        }

        [Test]
        [TestCase(2, 4, 2, -1)]
        public void TestQuadratic1Root(float a, float b, float c, float root)
        {
            // Arrange
            float[] expected = new float[] { root};
            // Act
            var actual = EquationSolver.SolveQuadratic(a, b, c);
            // Assert
            CollectionAssert.AreEquivalent(actual, expected);
        }

        [Test]
        [TestCase(2, 1, 9)]
        public void TestQuadraticComplexRoots(float a, float b, float c)
        {
            // Arrange
            float[] expected = new float[0];
            // Act
            var actual = EquationSolver.SolveQuadratic(a, b, c);
            // Assert
            CollectionAssert.AreEquivalent(actual, expected);
        }
    }
}