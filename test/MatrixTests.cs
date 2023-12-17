using NUnit.Framework;

namespace Intersect.Test {

    public class MatrixTests
    {
        [Test]
        public void TestDeterminant2x2()
        {
            // Arrange
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 3;
            matrix[0, 1] = 8;
            matrix[1, 0] = 4;
            matrix[1, 1] = 6;
            var expected = -14d;
            // Act
            var actual = matrix.Determinant();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeterminant3x3()
        {
            // Arrange
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 6;
            matrix[0, 1] = 1;
            matrix[0, 2] = 1;
            matrix[1, 0] = 4;
            matrix[1, 1] = -2;
            matrix[1, 2] = 5;
            matrix[2, 0] = 2;
            matrix[2, 1] = 8;
            matrix[2, 2] = 7;
            var expected = -306d;
            // Act
            var actual = matrix.Determinant();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeterminant4x4()
        {
            // Arrange
            var matrix = new Matrix(4, 4);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[0, 3] = 4;
            matrix[1, 0] = 5;
            matrix[1, 1] = 6;
            matrix[1, 2] = 7;
            matrix[1, 3] = 8;
            matrix[2, 0] = 9;
            matrix[2, 1] = 10;
            matrix[2, 2] = 6;
            matrix[2, 3] = 12;
            matrix[3, 0] = 13;
            matrix[3, 1] = 13;
            matrix[3, 2] = 15;
            matrix[3, 3] = 1;
            var expected = -240d;
            // Act
            var actual = matrix.Determinant();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMultiply2x2()
        {
            // Arrange
            var left = new Matrix(2, 2);
            left[0, 0] = 4;
            left[0, 1] = 7;
            left[1, 0] = 2;
            left[1, 1] = 6;
            var right = new Matrix(2, 2);
            right[0, 0] = .6d;
            right[0, 1] = -.7d;
            right[1, 0] = -.2d;
            right[1, 1] = .4d;
            var expected = new Matrix(2, 2);
            expected[0, 0] = 1;
            expected[1, 1] = 1;
            // Act
            var actual = left * right;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInverse2x2()
        {
            // Arrange
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 4;
            matrix[0, 1] = 7;
            matrix[1, 0] = 2;
            matrix[1, 1] = 6;
            var expected = new Matrix(2, 2);
            expected[0, 0] = .6d;
            expected[0, 1] = -.7d;
            expected[1, 0] = -.2d;
            expected[1, 1] = .4d;
            var identity = new Matrix(2, 2);
            identity[0, 0] = 1;
            identity[1, 1] = 1;
            // Act
            var inverse = matrix.Inversed();
            // Assert
            Assert.AreEqual(expected, inverse);
            Assert.AreEqual(identity, inverse * matrix);
            Assert.AreEqual(identity, matrix * inverse);
        }

        [Test]
        public void TestAdjoint3x3()
        {
            // Arrange
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 4;
            matrix[0, 1] = -2;
            matrix[0, 2] = 1;
            matrix[1, 0] = 5;
            matrix[1, 1] = 0;
            matrix[1, 2] = 3;
            matrix[2, 0] = -1;
            matrix[2, 1] = 2;
            matrix[2, 2] = 6;
            var expected = new Matrix(3, 3);
            expected[0, 0] = -6;
            expected[0, 1] = 14;
            expected[0, 2] = -6;
            expected[1, 0] = -33;
            expected[1, 1] = 25;
            expected[1, 2] = -7;
            expected[2, 0] = 10;
            expected[2, 1] = -6;
            expected[2, 2] = 10;
            var identity = new Matrix(3, 3);
            identity[0, 0] = 1;
            identity[1, 1] = 1;
            identity[2, 2] = 1;
            // Act
            var actual = matrix.Adjoint();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInverse3x3()
        {
            // Arrange
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 4;
            matrix[0, 1] = -2;
            matrix[0, 2] = 1;
            matrix[1, 0] = 5;
            matrix[1, 1] = 0;
            matrix[1, 2] = 3;
            matrix[2, 0] = -1;
            matrix[2, 1] = 2;
            matrix[2, 2] = 6;
            var expected = new Matrix(3, 3);
            expected[0, 0] = -3d/26;
            expected[0, 1] = 7d/26;
            expected[0, 2] = -3d/26;
            expected[1, 0] = -33d/52;
            expected[1, 1] = 25d/52;
            expected[1, 2] = -7d/52;
            expected[2, 0] = 5d/26;
            expected[2, 1] = -3d/26;
            expected[2, 2] = 5d/26;
            var identity = new Matrix(3, 3);
            identity[0, 0] = 1;
            identity[1, 1] = 1;
            identity[2, 2] = 1;
            // Act
            var inverse = matrix.Inversed();
            // Assert
            Assert.AreEqual(identity, expected * matrix);
            Assert.AreEqual(expected, inverse);
            Assert.AreEqual(identity, inverse * matrix);
            Assert.AreEqual(identity, matrix * inverse);
        }
    }
}