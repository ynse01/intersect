using System.Collections;
using System.Collections.Generic;

namespace Intersect
{
    internal class ListEnumerator<T> : IEnumerator<T> {
        private IReadOnlyList<T> list;
        private int index;

        public ListEnumerator(IReadOnlyList<T> list) {
            this.list = list;
            index = -1;
        }

        public T Current => list[index];

        object IEnumerator.Current => list[index];

        public void Dispose()
        {
            // Nothing to do here.
        }

        public bool MoveNext()
        {
            index++;
            return index < list.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    internal class SkipList<T> : IReadOnlyList<T> {
        private T[] content;
        private int offset;
        private int skip;

        public SkipList(T[] arr, int offset, int skip) {
            content = arr;
            this.offset = offset;
            this.skip = skip;
        }

        public T this[int index] => content[index * skip + offset];

        public int Count => content.Length / skip;

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }
    }
}