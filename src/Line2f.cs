namespace Intersect {

    public class Line2f
    {
        public Point2f Origin;

        public Vector2f Direction;

        public Point2f this[float index] => Origin + Direction * index;

        public float Project(Point2f point) {
            var vector = point - Origin;
            return Direction.Dot(vector);
        }
    }
}