namespace Intersect {

    public class Vector2f
    {
        public float X;

        public float Y;

        public float Dot(Vector2f other) {
            return X * other.X + Y * other.Y;
        }

        public float Cross(Vector2f other) {
            return X * other.Y - Y * other.X;
        }

        public static Vector2f operator +(Vector2f left, Vector2f right) {
            return new Vector2f() { 
                X = left.X + right.X,
                Y = left.Y + right.Y
            };
        }

        public static Vector2f operator -(Vector2f left, Vector2f right) {
            return new Vector2f() { 
                X = left.X - right.X,
                Y = left.Y - right.Y
            };
        }

        public static Vector2f operator *(Vector2f vector, float scalar) {
            return new Vector2f() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar
            };
        }

        public static Vector2f operator *(float scalar, Vector2f vector) {
            return new Vector2f() { 
                X = vector.X * scalar,
                Y = vector.Y * scalar
            };
        }
    }
}