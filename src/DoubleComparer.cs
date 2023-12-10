using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Intersect {

    public class DoubleComparer : IComparer, IComparer<double>, IEqualityComparer<double>
    {
        private const double Precision = 1e-6d;
        
        public static DoubleComparer Instance = new DoubleComparer();

        public int Compare(double x, double y)
        {
            var diff = x - y;
            if (double.IsNaN(diff)) {
                // We need to return something !
                return 1;
            }
            if (Math.Abs(diff) < Precision) {
                // X and Y are equal.
                return 0;
            }
            return Math.Sign(diff);
        }

        public int Compare(object x, object y)
        {
            if (x is double && y is double) {
                return Compare((double)x, (double)y);
            }
            return 0;
        }

        public bool Equals(double x, double y)
        {
            var diff = x - y;
            return Math.Abs(diff) < Precision;
        }

        public int GetHashCode(double obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}