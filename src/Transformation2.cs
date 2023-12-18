using System;

namespace Intersect {

    public class Transformation2
    {
        internal Matrix matrix;

        public Transformation2() {
            matrix = new Matrix(3, 3);
            matrix[0, 0] = matrix[1, 1] = matrix[2, 2] = 1d;
        }

        public static Transformation2 FromRotationAndTranslation(Angle theta, Vector2 translation) {
            var trans = new Transformation2();
            var cos = Math.Cos(theta.Radians);
            var sin = Math.Sin(theta.Radians);
            trans.matrix[0, 0] = cos;
            trans.matrix[0, 1] = sin;
            trans.matrix[0, 2] = translation.X;

            trans.matrix[1, 0] = -sin;
            trans.matrix[1, 1] = cos;
            trans.matrix[1, 2] = translation.Y;

            return trans;
        }

        public double this[int column, int row] {
            get {
                return matrix[column, row];
            }
            set {
                matrix[column, row] = value;
            }
        }

        public Point2 Transform(Point2 point) {
            var x = matrix[0, 0] * point.X + matrix[0, 1] * point.Y + matrix[0, 2];
            var y = matrix[1, 0] * point.X + matrix[1, 1] * point.Y + matrix[1, 2];
            var w = matrix[2, 2];
            return new Point2(x / w, y / w);
        }

        public Vector2 Transform(Vector2 vector) {
            var x = matrix[0, 0] * vector.X + matrix[0, 1] * vector.Y;
            var y = matrix[1, 0] * vector.X + matrix[1, 1] * vector.Y;
            var w = matrix[2, 2];
            return new Vector2(x / w, y / w);
        }

        internal string ToSvgTransform() {
            return $"matrix({matrix[0, 0]} {matrix[1, 0]} {matrix[0, 1]} {matrix[1, 1]} {matrix[0, 2]} {matrix[1, 2]})";
        }
    }
}