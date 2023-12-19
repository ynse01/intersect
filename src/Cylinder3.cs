
namespace Intersect {

    public class Cylinder3
    {
        public Point3 Origin;

        public Vector3 Axis;
        
        public double Height;

        public double Radius;

        public Cylinder3(Point3 origin, Vector3 axis, double height, double radius)
        {
            Origin = origin;
            Axis = axis;
            Height = height;
            Radius = radius;
        }
   }
}