using System;

namespace Intersect {

    public static class EquationSolver
    {
        public static float[] SolveQuadratic(float a, float b, float c) {
            var discriminant = b * b - 4 * a * c;
            var divider = 2 * a;
            if (discriminant == 0.0f) {
                return new float[] { -b / divider };
            } else if (discriminant > 0.0f) {
                var root = (float)Math.Sqrt(discriminant);
                return new float[] { (-b - root) / divider, (-b + root) / divider};
            }
            return new float[0];
        }
    }
}