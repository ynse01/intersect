using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Intersect {

    public class CollectionComparer<T> : IComparer, IComparer<IReadOnlyList<T>>, IEqualityComparer<IReadOnlyList<T>>
    {
        private IComparer<T> comparer;

        public CollectionComparer(IComparer<T> comparer) {
            this.comparer = comparer;
        }

        public int Compare(IReadOnlyList<T> x, IReadOnlyList<T> y)
        {
            if (x.Count != y.Count) {
                return Math.Sign(x.Count - y.Count);
            }
            for(int i = 0; i < x.Count; i++) {
                var result = comparer.Compare(x[i], y[i]);
                if (result != 0) {
                    return result;
                }
            }
            return 0;
        }

        public int Compare(object x, object y)
        {
            var left = x as IReadOnlyList<T>;
            var right = y as IReadOnlyList<T>;
            if (left != null && right != null) {
                return Compare(left, right);
            }
            return 0;
        }

        public bool Equals(IReadOnlyList<T> x, IReadOnlyList<T> y)
        {
            var diff = Compare(x, y);
            return diff == 0;
        }

        public int GetHashCode(IReadOnlyList<T> obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}