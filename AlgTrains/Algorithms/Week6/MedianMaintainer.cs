using AlgTrains.DataStructures;
using AlgTrains.Helper;
using AlgTrains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.Algorithms.Week6
{
    /// <summary>
    /// The goal of this problem is to implement the "Median Maintenance" algorithm (covered in the Week 5 lecture on heap applications). 
    /// The text file contains a list of the integers from 1 to 10000 in unsorted order; you should treat this as a stream of numbers, 
    /// arriving one by one. Letting xi denote the ith number of the file, the kth median mk is defined as the median of the numbers x1,…,xk. 
    /// (So, if k is odd, then mk is ((k+1)/2)th smallest number among x1,…,xk; if k is even, then mk is the (k/2)th smallest number among x1,…,xk.)
    /// </summary>
    public class MedianMaintainer : ITaskPerformer
    {
        private MinHeap<int> minHeap = new MinHeap<int>();
        private MaxHeap<int> maxHeap = new MaxHeap<int>();

        public string TaskDescription
        {
            get { return "Task 6.2: Maintain Median"; }
        }

        public string FileName
        {
            get { return "Median.txt"; }
        }

        public async Task PerformTask()
        {
            int[] array = await FileReader.ReadIntegerArray(@"Assets/" + FileName);

            if (array != null)
            {
                Queue<int> values = new Queue<int>(array);
                Benchmark.Start(TaskDescription);
                long result = ComputeMedian(values);
                Console.WriteLine(string.Format("Median: {0}", result));
                Benchmark.Finish();
            }
        }

        private long ComputeMedian(Queue<int> values)
        {
            long medianSum = 0;

            while(values.Any())
            {
                AddToHeap(values.Dequeue());
                medianSum = (medianSum + maxHeap.Peak()) % 10000;
            }

            return medianSum;
        }

        public void AddToHeap(int number)
        {
            if (maxHeap.Count == 0)
            {
                maxHeap.Push(number);
                return;
            }

            if (maxHeap.Peak() > number)
            {
                maxHeap.Push(number);
            }
            else
            {
                minHeap.Push(number);
            }

            if (maxHeap.Count - minHeap.Count > 1)
            {
                minHeap.Push(maxHeap.Pop());
                return;
            }

            if (minHeap.Count > maxHeap.Count)
            {
                maxHeap.Push(minHeap.Pop());
                return;
            }        
        }
    }
}
