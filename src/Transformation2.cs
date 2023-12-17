using System;

namespace Intersect {

    public class Transformation2
    {
        public double[] Matrix;

        public Transformation2() {
            Matrix = new double[9];
            Matrix[0] = Matrix[4] = Matrix[8] = 1d;
        }

        public static Transformation2 FromRotationAndTranslation(Angle theta, Vector2 translation) {
            var trans = new Transformation2();
            var cos = Math.Cos(theta.Radians);
            var sin = Math.Sin(theta.Radians);
            trans.Matrix[0] = cos;
            trans.Matrix[1] = -sin;
            trans.Matrix[2] = translation.X;

            trans.Matrix[3] = sin;
            trans.Matrix[4] = cos;
            trans.Matrix[5] = translation.Y;

            return trans;
        }

        public Point2 Transform(Point2 point) {
            var x = Matrix[0] * point.X + Matrix[1] * point.Y + Matrix[2];
            var y = Matrix[3] * point.X + Matrix[4] * point.Y + Matrix[5];
            var w = Matrix[8];
            return new Point2(x / w, y / w);
        }

        public Vector2 Transform(Vector2 vector) {
            var x = Matrix[0] * vector.X + Matrix[1] * vector.Y;
            var y = Matrix[3] * vector.X + Matrix[4] * vector.Y;
            var w = Matrix[8];
            return new Vector2(x / w, y / w);
        }
    }
}