namespace Intersect {

    public class Point2f
    {
        public float X;

        public float Y;

        public static Vector2f operator -(Point2f left, Point2f right) {
            return new Vector2f() { 
                X = left.X - right.X,
                Y = left.Y - right.Y
            };
        }

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