using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.DataStructures
{
    /// <summary>
    /// Abstract implementation of Heap data structure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class HeapBase<T> where T : IComparable<T>
    {
         private List<T> items = new List<T>();

         protected HeapBase(IEnumerable<T> items)
        {
            items = items.ToList();
            Heapify();
        }

        /// <summary>
        /// initialize all items
        /// </summary>
        private void Heapify()
        {
            for (var i = Count - 1; i >= 0; i--)
            {
                SiftUp(i);
            }
        }

        public int Count 
        { 
            get { 
                return items.Count; 
            } 
        }

        public void Push(T item)
        {
            items.Add(item);
            SiftUp(items.Count - 1);
        }

        public T Pop()
        {
            if (!items.Any()) throw new IndexOutOfRangeException();

            Swap(0, Count - 1);
            
            var item = items.Last();
            items.RemoveAt(Count - 1);

            PushDown(0);

            return item;
        }

        public T Peak()
        {
            return items[0];
        }

        private void SiftUp(int index)
        {
            if (index == 0) return;

            if (HasHigherPriority(items[index], items[(index - 1) / 2]))
            {
                Swap(index, (index - 1) / 2);
                SiftUp((index - 1) / 2);
            }
        }

        private void PushDown(int index)
        {
            var swapIndex = index;
            if (index * 2 + 1 < Count && HasHigherPriority(items[index * 2 + 1], items[index]))
                swapIndex = index * 2 + 1;
            if (index * 2 + 2 < Count && HasHigherPriority(items[index * 2 + 2], items[swapIndex]))
                swapIndex = index * 2 + 2;

            if (index == swapIndex) return;
            Swap(index, swapIndex);
            PushDown(swapIndex);
        }

        protected abstract bool HasHigherPriority(T a, T b);

        protected void Swap(int firstIndex, int secondIndex)
        {
            T aux = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = aux;
        }
    }
}
