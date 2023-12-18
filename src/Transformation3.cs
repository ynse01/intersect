
namespace Intersect {

    public class Transformation3
    {
        internal Matrix matrix;

        public Transformation3() {
            matrix = new Matrix(4, 4);
            matrix[0, 0] = matrix[1, 1] = matrix[2, 2] = matrix[3, 3] = 1d;
        }

        public static Transformation3 FromTranslation(Vector3 translation) {
            var trans = new Transformation3();
            trans.matrix[0, 3] = translation.X;
            trans.matrix[1, 3] = translation.Y;
            trans.matrix[1, 3] = translation.Z;
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

        public Point3 Transform(Point3 point) {
            var x = matrix[0, 0] * point.X + matrix[0, 1] * point.Y + matrix[0, 2] * point.Z + matrix[0, 3];
            var y = matrix[1, 0] * point.X + matrix[1, 1] * point.Y + matrix[1, 2] * point.Z + matrix[1, 3];
            var z = matrix[2, 0] * point.X + matrix[2, 1] * point.Y + matrix[2, 2] * point.Z + matrix[2, 3];
            var w = matrix[3, 3];
            return new Point3(x / w, y / w, z / w);
        }

        public Vector3 Transform(Vector3 vector) {
            var x = matrix[0, 0] * vector.X + matrix[0, 1] * vector.Y + matrix[0, 2] * vector.Z;
            var y = matrix[1, 0] * vector.X + matrix[1, 1] * vector.Y + matrix[1, 2] * vector.Z;
            var z = matrix[2, 0] * vector.X + matrix[2, 1] * vector.Y + matrix[2, 2] * vector.Z;
            var w = matrix[3, 3];
            return new Vector3(x / w, y / w, z / w);
        }
    }
}