using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    public class MaxHeap<T> : HeapBase<T> where T : IComparable<T>
    {
        public MaxHeap()
            : base(Enumerable.Empty<T>())
        {
        }

        public MaxHeap(IEnumerable<T> items)
            : base(items)
        {
        }

        protected override bool HasHigherPriority(T a, T b)
        {
            return a.CompareTo(b) >= 0;
        }
    }
}
