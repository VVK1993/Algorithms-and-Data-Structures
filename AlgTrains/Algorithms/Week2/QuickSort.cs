using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgTrains.Helper;

namespace AlgTrains.Algorithms.Week2
{
    public class QuickSort
    {
        /// <summary>
        /// Performs all tasks for Week 1 "Algorithms: Design and Analysis, Part 1" course
        /// </summary>
        public static void PerformAllTasks()
        {
            int[] unsortedArray = new int[] { 5, 1, 3, 6, 2, 4, 9, 8, 7 };
            unsortedArray.Print();
            Sort(unsortedArray, 0, unsortedArray.Length - 1);
            unsortedArray.Print();
        }

        public static void Sort(int[] array, int low, int high)
        {
            if (high <= low) return;

            int index = InPlacePartition(array, low, high);

            Sort(array, low, index);
            Sort(array, index + 1, high);
        }

        private static int InPlacePartition(int[] array, int low, int high)
        {
            int pivot = array[low];
            int i = low + 1;
            
            for(int j = low +1; j <= high; j++)
            {
                if(array[j] < pivot)
                {
                    array.Swap(j, i);
                    i++;
                }
            }

            array.Swap(low, i - 1);
            return i - 1;
        }

        private static int PartitiongAroundPivot(int[] array, int pivot, int low, int high)
        {
            int i = low;
            int j = high;
            int[] auxiliaryArray = new int[high + 1];
            int newIndex = 0;

            //copy initial array
            for (int k = low; k <= high; k++)
            {
                auxiliaryArray[k] = array[k];
            }

            for (int k = low; k <= high; k++)
            {
                if (auxiliaryArray[k] < pivot)
                {
                    array[i] = auxiliaryArray[k];
                    i++;
                }
                else if (auxiliaryArray[k] > pivot)
                {
                    array[j] = auxiliaryArray[k];
                    j--;
                }
                else
                {
                    array[i] = auxiliaryArray[k];
                    newIndex = i;
                    i++;
                }
            }

            return newIndex;
        }

        private static int GetPivotIndex(int[] array, int low, int high)
        {
            var rd = new Random();
            return low;
            //return rd.Next(low, high + 1);
        }
    }
}
