using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    public class MinHeap<T> : HeapBase<T> where T : IComparable
    {
        public MinHeap()
            : base(Enumerable.Empty<T>())
        {
        }

        public MinHeap(IEnumerable<T> items)
            : base(items)
        {
        }

        protected override bool HasHigherPriority(T a, T b)
        {
            return a.CompareTo(b) <= -1;
        }
    }
}
