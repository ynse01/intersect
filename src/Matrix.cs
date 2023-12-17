
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Intersect
{

    internal class Matrix
    {
        public double[] matrix;
        private int columnCount;
        private int rowCount;

        public Matrix(int numColumns, int numRows) {
            matrix = new double[numColumns * numRows];
            columnCount = numColumns;
            rowCount = numRows;
        }

        public double this[int col, int row] {
            get {
                return matrix[(row * columnCount) + col];
            }
            set {
                matrix[(row * columnCount) + col] = value;
            }
        }

        public Matrix Transposed() {
            var transposed = new Matrix(rowCount, columnCount);
            for (int y = 0; y < rowCount; y++) {
                for (int x = 0; x < columnCount; x++) {
                    transposed[y, x] = this[x, y];
                }
            }
            return transposed;
        }

        public Matrix Inversed() {
            return (1d / Determinant()) * Adjoint();
        }

        public double Determinant() {
            if (rowCount == 2 && columnCount == 2) {
                return this[0, 0] * this[1, 1] - this[1, 0] * this[0, 1];
            }
            double det = 0d;
            int factor = 1;
            for (int x = 0; x < columnCount; x++) {
                det += factor * this[x, 0] * Determinant(x, 0);
                factor *= -1;
            }
            return det;
        }

        public Matrix Adjoint() {
            if (columnCount != rowCount) {
                throw new ArgumentException("Can only calculate Adjoint on square matrices.");
            }
            var result = new Matrix(rowCount, columnCount);
            if (rowCount == 2) {
                var det = Determinant();
                result[0, 0] = this[1, 1];
                result[0, 1] = -this[0, 1];
                result[1, 0] = -this[1, 0];
                result[1, 1] = this[0, 0];
            } else {
                for (int y = 0; y < rowCount; y++) {
                    for (int x = 0; x < columnCount; x++) {
                        result[y, x] = MinusOnePower(x + y) * Determinant(x, y);
                    }
                }
            }

            return result;
        }

        public static Matrix operator +(Matrix left, Matrix right) {
            if (left.columnCount != right.columnCount || left.rowCount != right.rowCount) {
                throw new ArgumentException("Matrices should have same size.");
            }
            var result = new Matrix(right.columnCount, left.rowCount);
            for(int i = 0; i < left.matrix.Length; i++) {
                result.matrix[i] = left.matrix[i] + right.matrix[i];
            }
            return result;
        }

        public static Matrix operator -(Matrix left, Matrix right) {
            if (left.columnCount != right.columnCount || left.rowCount != right.rowCount) {
                throw new ArgumentException("Matrices should have same size.");
            }
            var result = new Matrix(right.columnCount, left.rowCount);
            for(int i = 0; i < left.matrix.Length; i++) {
                result.matrix[i] = left.matrix[i] - right.matrix[i];
            }
            return result;
        }

        public static Matrix operator *(Matrix left, Matrix right) {
            if (left.columnCount != right.rowCount) {
                throw new ArgumentException("Matrices do not have compatible size.");
            }
            var multiplied = new Matrix(right.columnCount, left.rowCount);
            for(int y = 0; y < multiplied.rowCount; y++) {
                for(int x = 0; x < multiplied.columnCount; x++) {
                    multiplied[x, y] = Dot(left.GetRow(x), right.GetColumn(y));
                }
            }
            return multiplied;
        }

        public static Matrix operator *(Matrix matrix, double scalar) {
            return scalar * matrix;
        }

        public static Matrix operator *(double scalar, Matrix matrix) {
            var multiplied = new Matrix(matrix.columnCount, matrix.rowCount);
            for(int i = 0; i < matrix.matrix.Length; i++) {
                multiplied.matrix[i] = scalar * matrix.matrix[i];
            }
            return multiplied;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Matrix;
            if (other != null) {
                var comparer =  new CollectionComparer<double>(DoubleComparer.Instance);
                return comparer.Equals(matrix, other.matrix);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for(int y = 0; y < rowCount; y++) {
                builder.Append("[");
                builder.Append(string.Join(", ", GetRow(y)));
                builder.AppendLine("]");
            }
            return builder.ToString();
        }

        private IReadOnlyList<double> GetColumn(int index) {
            return new SkipList<double>(matrix, index, columnCount);
        }

        private IReadOnlyList<double> GetRow(int index) {
            return new ArraySegment<double>(matrix, index * columnCount, columnCount);
        }

        private static double Dot(IReadOnlyList<double> left, IReadOnlyList<double> right) {
            double result = 0d;
            for(int i =0; i < left.Count; i++) {
                result += left[i] * right[i];
            }
            return result;
        }

        private double Determinant(int x, int y) {
            return Remainder(x, y).Determinant();
        }

        private Matrix Remainder(int column, int row) {
            var remainder = new Matrix(columnCount - 1, rowCount - 1);
            int j = 0;
            for(int y = 0; y < rowCount; y++) {
                if (y == row) continue;
                int i = 0;
                for(int x = 0; x < columnCount; x++) {
                    if (x == column) continue;
                    remainder[i, j] = this[x, y];
                    i++;
                }
                j++;
            }
            return remainder;
        }

        private double MinusOnePower(int power) {
            return (power & 1) == 0 ? 1 : -1;
        }
    }
}