﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgTrains.Helper;
using AlgTrains.Interfaces;

namespace AlgTrains.Algorithms.Week2
{
    public class QuickSort : ITaskPerformer
    {
        private static int counter = 0;

        public string TaskDescription
        {
            get { return "Task 2: Counting QuickSort Comparisons"; }
        }

        public string FileName
        {
            get { return "QuickSort.txt"; }
        }

        /// <summary>
        /// Performs all tasks for Week 2 "Algorithms: Design and Analysis, Part 1" course
        /// </summary>
        public async Task PerformTask()
        {
            int[] array = await FileReader.ReadIntegerArray(@"Assets/" + FileName);

            if (array != null)
            {
                counter = 0;
                Benchmark.Start(TaskDescription);
                Task1(array.CreateCopy(), 0, array.Length - 1);
                Console.WriteLine(string.Format("Case 1 comparisons: {0}", counter));

                counter = 0;
                Task2(array.CreateCopy(), 0, array.Length - 1);
                Console.WriteLine(string.Format("Case 2 comparisons: {0}", counter));

                counter = 0;
                Task3(array.CreateCopy(), 0, array.Length - 1);
                Console.WriteLine(string.Format("Case 3 comparisons: {0}", counter));
                Benchmark.Finish();
            }
        }

        public static int RandomSelection(int[] array, int start, int end, int i)
        {
            if (end == start)
                return array[start];

            if (start < end)
            {
                int mid = InPlacePartition(array, start, end, GetPivot(start, end));
                int k = mid - start + 1;
                if (i == k)
                    return array[mid];
                else if (i < k)
                    return RandomSelection(array, start, mid - 1, i);
                else
                    return RandomSelection(array, mid + 1, end, i - k);
            }
            else //error 
                return - 1;
        }

        private static void Task1(int[] array, int low, int high)
        {
            if (high <= low) return;

            int index = InPlacePartitionFirstElement(array, low, high);

            counter += high - low;

            Task1(array, low, index - 1);
            Task1(array, index + 1, high);
        }

        private static void Task2(int[] array, int low, int high)
        {
            if (high <= low) return;

            int index = InPlacePartitionLastElement(array, low, high);

            counter += high - low;

            Task2(array, low, index - 1);
            Task2(array, index + 1, high);
        }

        private static void Task3(int[] array, int low, int high)
        {
            if (high <= low) return;

            int index = InPlacePartitionMedianElement(array, low, high);

            counter += high - low;

            Task3(array, low, index - 1);
            Task3(array, index + 1, high);
        }

        public static void Sort(int[] array, int low, int high)
        {
            if (high <= low) return;

            int pivot = GetPivot(low, high);
            int index = InPlacePartition(array, low, high, pivot);

            Sort(array, low, index);
            Sort(array, index + 1, high);
        }

        private static int GetPivot(int low, int high)
        {
            var rd = new Random();
            return rd.Next(low, high + 1);
        }

        /// <summary>
        /// Running time = O(n)
        /// Where n = high - (low +1)
        /// O(1) work per array entry
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int InPlacePartitionFirstElement(int[] array, int low, int high)
        {
            int pivot = array[low];
            int i = low + 1;

            for (int j = low + 1; j <= high; j++)
            {
                if (array[j] < pivot)
                {
                    array.Swap(j, i);
                    i++;
                }
            }

            array.Swap(low, i - 1);
            return i - 1;
        }

        private static int InPlacePartitionLastElement(int[] array, int low, int high)
        {
            array.Swap(high, low);
            int pivot = array[low];
            int i = low + 1;

            for (int j = low + 1; j <= high; j++)
            {
                if (array[j] < pivot)
                {
                    array.Swap(j, i);
                    i++;
                }
            }

            array.Swap(low, i - 1);
            return i - 1;
        }

        private static int InPlacePartitionMedianElement(int[] array, int low, int high)
        {
            int firstElement = array[low];
            int finalElement = array[high];

            int medianIndex = low + (high - low) / 2;
            int middleElement = array[(medianIndex)];
            int median = low;
            if ((firstElement > middleElement && firstElement < finalElement) || (firstElement < middleElement && firstElement > finalElement))
            {
                median = low;
            }

            if ((middleElement > firstElement && middleElement < finalElement) || (middleElement < firstElement && middleElement > finalElement))
            {
                median = medianIndex;
            }

            if ((finalElement > firstElement && finalElement < middleElement) || (finalElement < firstElement && finalElement > middleElement))
            {
                median = high;
            }

            if (median != low)
            {
                array.Swap(low, median);
            }

            //Putting the last element as the first
            int pivot = array[low];
            int i = low + 1;
            for (int j = low + 1; j <= high; j++)
            {
                if (array[j] < pivot)
                {
                    array.Swap(j, i);
                    i++;
                }
            }

            array.Swap(low, i - 1);
            return i - 1;
        }

        private static int InPlacePartition(int[] array, int low, int high, int pivot)
        {
            int i = low + 1;

            for (int j = low + 1; j <= high; j++)
            {
                if (array[j] < pivot)
                {
                    array.Swap(j, i);
                    i++;
                }
            }

            array.Swap(low, i - 1);
            return i - 1;
        }
    }
}
