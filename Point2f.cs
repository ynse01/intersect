namespace Intersect {

    public class Point2f
    {
        public float X;

        public float Y;

        public static Point2f operator +(Point2f point, Vector2f vector) {
            return new Point2f() {
                X = point.X + vector.X,
                Y = point.Y + vector.Y
            };
        }

        public static Point2f operator -(Point2f point, Vector2f vector) {
            return new Point2f() {
                X = point.X - vector.X,
                Y = point.Y - vector.Y
            };
        }
    }
}