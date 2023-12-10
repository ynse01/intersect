using System;
using System.Collections.Generic;

namespace Intersect {

    public static class EquationSolver
    {
        public static float SolveLinear(float a, float b) {
            return -b / a;
        }

        public static IList<float> SolveQuadratic(float a, float b, float c) {
            List<float> output = new List<float>();
            if (a == 0f) {
                output.Add(SolveLinear(b, c));
                return output;
            }
            var discriminant = b * b - 4.0f * a * c;
            var divider = 2.0f * a;
            if (discriminant == 0.0f) {
                output.Add(-b / divider);
            } else if (discriminant > 0.0f) {
                var root = (float)Math.Sqrt(discriminant);
                output.Add((-b - root) / divider);
                output.Add((-b + root) / divider);
            }
            return output;
        }

        public static IList<float> SolveQubic(float a, float b, float c, float d) {
            // Taken from: https://stackoverflow.com/questions/49671821/implementing-cardano-method-for-a-cubic-equation-solution
            // And: https://en.wikipedia.org/wiki/Cubic_equation#Depressed_cubic
            List<float> output = new List<float>();
            if (a == 0f) {
                return SolveQuadratic(b, c, d);
            }
            double a1 = b / a;
            double a2 = c / a;
            double a3 = d / a;
            double p = a2 - (a1 * a1 / 3d);
            double q = (2d * a1 * a1 * a1 / 27d) - (a1 * a2 / 3d) + a3;
            double cubeDiscr = q * q / 4d + p * p * p / 27d;
            if (cubeDiscr > 0) {
                double u = CubicRoot(-q / 2d + Math.Sqrt(cubeDiscr));
                double v = CubicRoot(-q / 2d - Math.Sqrt(cubeDiscr));
                output.Add((float)(u + v - (a1 / 3d)));
            }
            else if (cubeDiscr == 0) {
                double u = CubicRoot(-q / 2d);
                if (q != 0d) {
                    // Prevent duplicate result.
                    output.Add((float)(2d * u - (a1 / 3d)));
                }
                output.Add((float)(-u - (a1 / 3d)));
            }
            else if (cubeDiscr < 0) {
                double u = 2d * Math.Sqrt(p / -3d);
                double theta = Math.Acos(3d * q * Math.Sqrt(-3d / p) / (2d * p)) / 3d;
                for(int i = 0; i < 3; i++) {
                    double t = u * Math.Cos(theta - 2d * Math.PI * i / 3d);
                    output.Add((float)(t - a1 / 3d));
                }
            }
            return output;
        }

        private static double CubicRoot(double n) {
            return Math.Pow(Math.Abs(n), 1d / 3d) * Math.Sign(n);
        }
    }
}