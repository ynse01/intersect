﻿using System;

namespace Intersect {

    public class Ellipse2
    {
        public Point2 Origin;

        public Vector2 Direction;

        public double MajorRadius;

        public double MinorRadius;

        public double Area() {
            return Math.PI * MajorRadius * MinorRadius;
        }
    }
}