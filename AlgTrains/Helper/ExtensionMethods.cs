using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Author: Vladimir Kovtunovskiy
namespace AlgTrains.Helper
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Check if array of inegers is sorted
        /// </summary>
        /// <param name="array">array of intgeres</param>
        /// <returns>True if all elements are sorted. False otherwise</returns>
        public static bool IsSorted(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Check if array of inegers is sorted
        /// </summary>
        /// <param name="array">array of intgeres</param>
        /// <param name="low">index of the first element</param>
        /// <param name="high">index of the last element</param>
        /// <returns>True if all elements are sorted. False otherwise</returns>
        public static bool IsSorted(this int[] array, int low, int high)
        {
            for (int i = low; i <= high; i++)
            {
                for (int j = i + 1; j <= high; j++)
                {
                    if (array[i] > array[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Prints numbers of the array in one line
        /// </summary>
        /// <param name="array">array of intgeres</param>
        public static void Print(this int[] array)
        {
            string output = "";

            foreach (int i in array)
            {
                output += i + " ";
            }

            Console.WriteLine(output);
        }


        public static void Swap(this int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
