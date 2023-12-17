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
    }
}