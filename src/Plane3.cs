
namespace Intersect {

    public class Plane3
    {
        public Vector3 Normal;

        public Point3 Origin;

        public Plane3(Point3 origin, Vector3 normal)
        {
            Origin = origin;
            Normal = normal;
        }

        public CartesianSpace Space() {
            return CartesianSpace.FromNormal(Origin, Normal);
        }

        public bool IsOnPlane(Point3 point) {
            // When difference is perpendicular to the Normal, 'point' lies on the plane.
            var diff = Origin - point;
            return DoubleComparer.Instance.Equals(Normal.Dot(diff), 0d);
        }
    }
}