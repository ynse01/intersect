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
        public void TestLinear(double a, double b)
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
        [TestCase(0, 2, 1, 1)]
        public void TestQuadratic(double a, double b, double c, int numRoots)
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
        [TestCase(0, -4, 2, 6, 2)]
        public void TestQubic(double a, double b, double c, double d, int numRoots)
        {
            // Arrange
            // Act
            var actual = EquationSolver.SolveQubic(a, b, c, d);
            // Assert
            Assert.AreEqual(numRoots, actual.Count);
            AssertResults(actual, (x) => a * x * x * x + b * x * x + c * x + d);
        }

        [Test]
        [TestCase(1, 0, 0, 0, -6, 0)]
        [TestCase(1, 0, -2, 0, 3, 0)]
        [TestCase(1, 4, -9, 4, 1, 2)]
        [TestCase(1, 7, 49, 343, 2401, 0)]
        [TestCase(1, 2, -897, 60002, 000000, 2)]
        public void TestQuartic(double a, double b, double c, double d, double e, int numRoots)
        {
            // Arrange
            // Act
            var actual = EquationSolver.SolveQuartic(a, b, c, d, e);
            // Assert
            Assert.AreEqual(numRoots, actual.Count);
            AssertResults(actual, (x) => a * x * x * x * x + b * x * x * x + c * x * x + d * x + e);
        }

        private void AssertResults(IList<double> results, Func<double, double> expected) {
            List<double> actual = new List<double>();
            List<double> zeros = new List<double>();
            foreach(var x in results) {
                actual.Add(expected(x));
                zeros.Add(0f);
            }
            CollectionAssert.AreEqual(zeros, actual, DoubleComparer.Instance);
        }
    }
}