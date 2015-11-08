using AlgTrains.Helper;
using AlgTrains.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Author: Vladimir Kovtunovskiy
namespace AlgTrains.Algorithms.Week1
{
    /// <summary>
    /// Contains algortihms for 
    /// MergeSort, 
    /// InversionCount (fast and slow), 
    /// Karatsuba Multiplication
    /// </summary>
    public class DivideAndConquer : ITaskPerformer
    {
        public string TaskDescription
        {
            get { return "Task 1: Counting Inversions"; }
        }

        public string FileName
        {
            get { return "IntegerArray.txt"; }
        }

        /// <summary>
        /// Performs all tasks for Week 1 "Algorithms: Design and Analysis, Part 1" course
        /// </summary>
        public async Task PerformTask()
        {
            int[] array = await FileReader.ReadIntegerArray(@"Assets/" + FileName);

            if (array != null)
            {
                Benchmark.Start(TaskDescription);
                long inversions = GetInversionsCount(array, 0, array.Length - 1);
                Benchmark.Finish();
                Console.WriteLine(string.Format("Amount of inversions: {0}", inversions));
            }

            int[] unsortedArray = new int[] { 5, 1, 3, 6, 3, 2, 4, 9, 8, 7 };
            MergeSort(unsortedArray, 0, unsortedArray.Length - 1);
        }

        /// <summary>
        /// Running time = O(n^2) 
        /// very slow straighforward algorithm
        /// </summary>
        /// <param name="array">array of integers with inversions</param>
        /// <returns>amount of inversions in given array</returns>
        public static long GetInversionsCountSlow(int[] array)
        {
            int inversionCounter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        inversionCounter++;
                    }
                }
            }
            return inversionCounter;
        }

        /// <summary>
        /// Running time = O(nlog(n))
        /// fast divide and conquer algorithm
        /// </summary>
        /// <param name="array">array of integers with inversions</param>
        /// <returns>amount of inversions in given array</returns>
        private static long GetInversionsCount(int[] array, int low, int high)
        {
            //Checks preconditions
            Debug.Assert(high < array.Length, "High parameter must be less than array length!");
            Debug.Assert(low >= 0, "Low parameter must be more or equal to zero!");

            if (high <= low) return 0;
            int mid = low + (high - low) / 2;
            return GetInversionsCount(array, low, mid) + GetInversionsCount(array, mid + 1, high)
                + CountSplitInversion(array, low, mid, high);
        }

        /// <summary>
        /// Running time = O(n)
        /// counts amount of inversions
        /// </summary>
        /// <param name="array">array of integers</param>
        /// <param name="low">index of the first element</param>
        /// <param name="mid">index of the midle element</param>
        /// <param name="high">index of the last element</param>
        private static long CountSplitInversion(int[] array, int low, int mid, int high)
        {
            long counter = 0;
            int[] auxiliaryArray = new int[array.Length];

            //copy initial array
            for (int k = low; k <= high; k++)
            {
                auxiliaryArray[k] = array[k];
            }

            int i = low;
            int j = mid + 1;

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    //left part of the array is sorted
                    array[k] = auxiliaryArray[j++];
                }
                else if (j > high)
                {
                    //right part of the array is sorted
                    array[k] = auxiliaryArray[i++];
                }
                else if (auxiliaryArray[j] < auxiliaryArray[i])
                {
                    array[k] = auxiliaryArray[j++];
                    //increment by number of elements remaining in left part of the array
                    counter += (mid + 1) - i;
                }
                else
                {
                    array[k] = auxiliaryArray[i++];
                }
            }

            return counter;
        }

        /// <summary>
        /// Running time = O(n^2)
        /// assume x and y are the same length
        /// Uses 4 Recursive calls
        /// </summary>
        /// <param name="x">first number</param>
        /// <param name="y">second number</param>
        /// <returns>product of x * y</returns>
        public static double KaratsubaMultiplicationSlow(int x, int y)
        {
            var n = x.ToString().Length;

            if (x < 10 || y < 10)
            {
                return x * y;
            }

            int a = int.Parse(x.ToString().Remove(n / 2));
            int b = int.Parse(x.ToString().Remove(0, n / 2));
            int c = int.Parse(y.ToString().Remove(n / 2));
            int d = int.Parse(y.ToString().Remove(0, n / 2));

            var ac = KaratsubaMultiplicationSlow(a, c);
            var bd = KaratsubaMultiplicationSlow(b, d);
            var ad = KaratsubaMultiplicationSlow(a, d);
            var bc = KaratsubaMultiplicationSlow(b, c);

            return Math.Pow(10, n) * ac + Math.Pow(10, n / 2) * (ad + bc) + bd;
        }

        /// <summary>
        /// Running time = O(n^1.59)
        /// assume x and y are the same length
        /// Uses 3 Recursive calls. Much faster
        /// </summary>
        /// <param name="x">first number</param>
        /// <param name="y">second number</param>
        /// <returns>product of x * y</returns>
        public static double KaratsubaMultiplication(int x, int y)
        {
            var n = x.ToString().Length;

            if (x < 10 || y < 10)
            {
                return x * y;
            }

            int a = int.Parse(x.ToString().Remove(n / 2));
            int b = int.Parse(x.ToString().Remove(0, n / 2));
            int c = int.Parse(y.ToString().Remove(n / 2));
            int d = int.Parse(y.ToString().Remove(0, n / 2));

            var ac = KaratsubaMultiplication(a, c);
            var bd = KaratsubaMultiplication(b, d);
            var sumProduct = KaratsubaMultiplication((a + b), (c + d));
            //Gauss' Trick
            var result = sumProduct - ac - bd;

            return Math.Pow(10, n) * ac + Math.Pow(10, n / 2) * (result) + bd;
        }

        /// <summary>
        /// Running time = O(n)
        /// Merges and sorts two parts of the array
        /// </summary>
        /// <param name="array">
        /// Precondition 1 array[low...mid] is sorted
        /// Precondition 2 array[mid+1...high] is sorted
        /// </param>
        /// <param name="low">index of the first element</param>
        /// <param name="mid">index of the midle element</param>
        /// <param name="high">index of the last element</param>
        private static void Merge(int[] array, int low, int mid, int high)
        {
            //Checks preconditions
            Debug.Assert(array.IsSorted(low, mid), "Left part of the array must be sorted!");
            Debug.Assert(array.IsSorted(mid + 1, high), "Right part of the array must be sorted!");

            int[] auxiliaryArray = new int[array.Length];

            //copy initial array
            for (int k = low; k <= high; k++)
            {
                auxiliaryArray[k] = array[k];
            }

            int i = low;
            int j = mid + 1;

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    //left part of the array is sorted
                    array[k] = auxiliaryArray[j++];
                }
                else if (j > high)
                {
                    //right part of the array is sorted
                    array[k] = auxiliaryArray[i++];
                }
                else if (auxiliaryArray[j] < auxiliaryArray[i])
                {
                    array[k] = auxiliaryArray[j++];
                }
                else
                {
                    array[k] = auxiliaryArray[i++];
                }
            }
        }

        /// <summary>
        /// Running time = O(nlog(n))
        /// Implementation of the standard merge sort
        /// </summary>
        /// <param name="array">unsorted array</param>
        /// <param name="low">index of the first element</param>
        /// <param name="high">index of the last element</param>
        public static void MergeSort(int[] array, int low, int high)
        {
            //Checks preconditions
            Debug.Assert(high < array.Length, "High parameter must be less than array length!");
            Debug.Assert(low >= 0, "Low parameter must be more or equal to zero!");

            if (high <= low) return;
            int mid = low + (high - low) / 2;
            MergeSort(array, low, mid);
            MergeSort(array, mid + 1, high);
            Merge(array, low, mid, high);
        }
    }
}
