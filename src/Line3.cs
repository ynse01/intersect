
using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Intersect {

    public class Line3
    {
        public Point3 Origin;

        public Vector3 Direction;

        public static Line3 FromPoints(Point3 start, Point3 end) {
            return new Line3(start, end - start);
        }

        public Line3(Point3 origin, Vector3 direction) {
            Origin = origin;
            Direction = direction;
        }

        public Point3 this[double x] {
            get {
                return Origin + x * Direction;
            }
        }

        public double Project(Point3 point) {
            var vector = point - Origin;
            return Direction.Dot(vector);
        }

        public Point3 Symmetric(Point3 point) {
            var projected = this[Project(point)];
            return point + 2d * (point - projected);
        }

        public override bool Equals(object obj)
        {
            if (obj is Line3) {
                var other = (Line3)obj;
                return Origin.Equals(other.Origin) && Direction.Equals(other.Direction);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        public override string ToString()
        {
            return $"Line3({Origin} -> {Direction})";
        }
    }
}