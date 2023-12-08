namespace Intersect {

    public class Vector2f
    {
        public float X;

        public float Y;

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