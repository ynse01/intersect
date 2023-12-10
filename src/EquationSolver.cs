using System;
using System.Collections.Generic;

namespace Intersect {

    public static class EquationSolver
    {
        public static double SolveLinear(double a, double b) {
            return -b / a;
        }

        public static IList<double> SolveQuadratic(double a, double b, double c) {
            List<double> output = new List<double>();
            if (a == 0d) {
                output.Add(SolveLinear(b, c));
                return output;
            }
            var discriminant = b * b - 4d * a * c;
            var divider = 2d * a;
            if (discriminant == 0d) {
                output.Add(-b / divider);
            } else if (discriminant > 0d) {
                var root = (float)Math.Sqrt(discriminant);
                output.Add((-b - root) / divider);
                output.Add((-b + root) / divider);
            }
            return output;
        }

        public static IList<double> SolveQubic(double a, double b, double c, double d) {
            // Taken from: https://stackoverflow.com/questions/49671821/implementing-cardano-method-for-a-cubic-equation-solution
            // And: https://en.wikipedia.org/wiki/Cubic_equation#Depressed_cubic
            List<double> output = new List<double>();
            if (a == 0d) {
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
                output.Add(u + v - (a1 / 3d));
            }
            else if (cubeDiscr == 0) {
                double u = CubicRoot(-q / 2d);
                if (q != 0d) {
                    // Prevent duplicate result.
                    output.Add(2d * u - (a1 / 3d));
                }
                output.Add(-u - (a1 / 3d));
            }
            else if (cubeDiscr < 0) {
                double u = 2d * Math.Sqrt(p / -3d);
                double theta = Math.Acos(3d * q * Math.Sqrt(-3d / p) / (2d * p)) / 3d;
                for(int i = 0; i < 3; i++) {
                    double t = u * Math.Cos(theta - 2d * Math.PI * i / 3d);
                    output.Add(t - a1 / 3d);
                }
            }
            return output;
        }

        public static IList<double> SolveQuartic(double a, double b, double c, double d, double e) {
            // Taken fom: https://en.wikipedia.org/wiki/Quartic_function
            List<double> output = new List<double>();
            if (a == 0d) {
                return SolveQubic(b, c, d, e);
            }
            double a1 = b / a;
            double a2 = c / a;
            double a3 = d / a;
            //double a4 = e / a;
            double p = a2 - (a1 * a1 * 3d / 8d);
            double q = (a1 * a1 * a1 / 8d) - (a1 * a2 / 2d) + a3;
            double discriminant0 = c * c - 3d * b * d + 12d * a * e;
            double discriminant1 = 2d * c * c *c - 9d * b * c * d + 27d * b * b * e + 27d * a * d * d - 72d * a * c * e;
            double qTerm = discriminant1 * discriminant1 - 4d * discriminant0 * discriminant0 * discriminant0;
            double discriminant = qTerm / -27d;
            Console.WriteLine($"Discriminant: {discriminant}");
            double s;
            if (discriminant > 0d) {
                var theta = Math.Acos(discriminant1 / (2d * Math.Sqrt(discriminant0 * discriminant0 * discriminant0))) / 3d;
                s = Math.Sqrt(-2d / 3d * p + 2d / (3d * a) * Math.Sqrt(discriminant0) * Math.Cos(theta)) / 2d;
            } else {
                double Q = CubicRoot((discriminant1 + Math.Sqrt(qTerm)) / 2d);
                s = Math.Sqrt((-2d * p / 3d) + (Q + discriminant0 / Q) / (3d * a)) / 2d;
            }
            double xFirstTerm = a1 / -4d;
            double xSecondTermPos = Math.Sqrt(-4d * s * s - 2d * p + q / s) / 2d;
            double xSecondTermNeg = Math.Sqrt(-4d * s * s - 2d * p - q / s) / 2d;
            if (!double.IsNaN(xSecondTermPos)) {
                output.Add(xFirstTerm - s + xSecondTermPos);
                output.Add(xFirstTerm - s - xSecondTermPos);
            }
            if (!double.IsNaN(xSecondTermNeg)) {
                output.Add(xFirstTerm + s + xSecondTermNeg);
                output.Add(xFirstTerm + s - xSecondTermNeg);
            }
            return output;
        }

        private static double CubicRoot(double n) {
            return Math.Pow(Math.Abs(n), 1d / 3d) * Math.Sign(n);
        }
    }
}