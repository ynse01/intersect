using System;
using System.Collections;
using System.Collections.Generic;
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
            AssertResults(new [] { actual }, (x) => a * x + b);
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
            AssertResults(actual, (x) => a * x * x + b * x + c);
        }

        [Test]
        [TestCase(1, -3, 3, -1, 1)]
        [TestCase(1, -7, 7, 15, 3)]
        [TestCase(1, -5, -2, 24, 3)]
        public void TestQubic(float a, float b, float c, float d, int numRoots)
        {
            // Arrange
            // Act
            var actual = EquationSolver.SolveQubic(a, b, c, d);
            // Assert
            Assert.AreEqual(numRoots, actual.Count);
            AssertResults(actual, (x) => a * x * x * x + b * x * x + c * x + d);
        }

        private void AssertResults(IList<float> results, Func<float, float> expected) {
            List<float> actual = new List<float>();
            List<float> zeros = new List<float>();
            foreach(var x in results) {
                actual.Add(expected(x));
                zeros.Add(0f);
            }
            CollectionAssert.AreEqual(zeros, actual);
        }
    }
}