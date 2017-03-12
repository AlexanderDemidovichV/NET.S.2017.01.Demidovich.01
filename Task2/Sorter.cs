using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Performs static methods for sorting integer arrays.
    /// </summary>
    public static class Sorter
    {
        #region Public Methods

        /// <summary>
        /// Sorts the elements in an System.Array using the specified System.Comparison.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array to sort.</param>
        /// <param name="comparison">The System.Comparison to use when comparing elements.</param>
        public static void Sort(this int[] array, Comparison<int> comparison)
        {
            Merge_Sort(array, comparison);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sorts the elements in an System.Array using the specified System.Comparison.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array to sort.</param>
        /// <param name="comparison">The System.Comparison to use when comparing elements.</param>
        /// <exception cref="System.ArgumentNullException">array is null.-or-comparison is null.</exception>
        private static void Merge_Sort(int[] array, Comparison<int> comparison)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));

            int[] sorted_array = Top_Down_Split_Merge(array, comparison);

            Array.Copy(sorted_array, array, array.Length);
        }

        /// <summary>
        /// Divide the unsorted array into subarrays until subarray size is 1, then merges those subarrays to produce a sorted array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array to sort.</param>
        /// <param name="comparison">The System.Comparison to use when comparing elements.</param>
        /// <returns>A sorted array.</returns>
        private static int[] Top_Down_Split_Merge(int[] array, Comparison<int> comparison)
        {
            if (array.Length == 1)
                return array;

            int mid_point = array.Length / 2;

            return Merge(Top_Down_Split_Merge(array.Take(mid_point).ToArray(), comparison), 
                Top_Down_Split_Merge(array.Skip(mid_point).ToArray(), comparison),
                comparison);
            
        }

        /// <summary>
        /// Merge two arrays into a single sorted one.
        /// </summary>
        /// <param name="array1">The first array to merge.</param>
        /// <param name="array2">The second array to merge.</param>
        /// <param name="comparison">The System.Comparison to use when comparing elements.</param>
        /// <returns>A sorted array.</returns>
        private static int[] Merge(int[] array1, int[] array2, Comparison<int> comparison)
        {
            int array1_index = 0, array2_index = 0;
            int[] merged = new int[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (array2_index < array2.Length && array1_index < array1.Length)
                {
                    if (comparison(array1[array1_index], array2[array2_index]) > 0)
                        merged[i] = array2[array2_index++];
                    else
                        merged[i] = array1[array1_index++];
                }
                else
                {
                    if (array2_index < array2.Length)
                        merged[i] = array2[array2_index++];
                    else
                        merged[i] = array1[array1_index++];
                }
            }
            return merged;
        }
        #endregion
    }
}
