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
            List<float> output = new List<float>();
            if (a != 0) {
                float a1 = b / a;
                float a2 = c / a;
                float a3 = d / a;
                float p = -(a1 * a1 / 3.0f) + a2;
                float q = (2.0f * a1 * a1 * a1 / 27.0f) - (a1 * a2 / 3.0f) + a3;
                float cubeDiscr = q * q / 4.0f + p * p * p / 27.0f;
                if (cubeDiscr > 0) {
                    float u = CubicRoot(-q / 2.0 + Math.Sqrt(cubeDiscr));
                    float v = CubicRoot(-q / 2.0 - Math.Sqrt(cubeDiscr));
                    output.Add(u + v - (a1 / 3.0f));
                }
                else if (cubeDiscr == 0) {
                    float u = CubicRoot(-q / 2.0f);
                    if (u != 0.0f) {
                        // Prevent duplicate result.
                        output.Add(2.0f * u - (a1 / 3.0f));
                    }
                    output.Add(-u - (a1 / 3.0f));
                }
                else if (cubeDiscr < 0) {
                    float r = CubicRoot(Math.Sqrt(-(p * p * p / 27.0f)));
                    float alpha = (float)Math.Atan(Math.Sqrt(-cubeDiscr) / (-q / 2.0));
                    output.Add(r * (float)(Math.Cos(alpha / 3.0f) + Math.Cos((6.0f * Math.PI - alpha) / 3.0f)) - a1 / 3.0f);
                    output.Add(r * (float)(Math.Cos((2.0f * Math.PI + alpha) / 3.0f) + Math.Cos((4.0f * Math.PI - alpha) / 3.0)) - a1 / 3.0f);
                    output.Add(r * (float)(Math.Cos((4.0f * Math.PI + alpha) / 3.0f) + Math.Cos((2.0f * Math.PI - alpha) / 3.0)) - a1 / 3.0f);
                }
            }
            return output;
        }

        private static float CubicRoot(double n) {
            return (float)(Math.Pow(Math.Abs(n), 1f / 3f) * Math.Sign(n));
        }
    }
}