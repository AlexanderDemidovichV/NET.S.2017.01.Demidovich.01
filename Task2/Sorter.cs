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
        /// Sorts the elements in a one-dimensional Array using the specified IComparer.
        /// </summary>
        /// <param name="array">The one-dimensional Array to sort.</param>
        /// <param name="comparer">The System.Collections.IComparer implementation to use when comparing elements.-or-null
        ///    to use the System.IComparable implementation of each element.</param>
        public static void Sort(this int[] array, IComparer comparer)
        {
            ExecuteSort(array, comparer);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Executes the sort.
        /// </summary>
        /// <param name="array">The one-dimensional Array to sort.</param>
        /// <param name="comparer">The System.Collections.IComparer implementation to use when comparing elements.-or-null
        ///    to use the System.IComparable implementation of each element.</param>
        private static void ExecuteSort(int[] array, IComparer comparer)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int[] result = Merge_Sort(array, comparer);

            Array.Copy(result, array, result.Length);
        }
        private static int[] Merge_Sort(int[] array, IComparer comparer)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int mid_point = array.Length / 2;

            return Merge(Merge_Sort(array.Take(mid_point).ToArray(), comparer), 
                Merge_Sort(array.Skip(mid_point).ToArray(), comparer), 
                comparer);
            
        }

        private static int[] Merge(int[] array1, int[] array2, IComparer comparer)
        {
            int a = 0, b = 0;
            int[] merged = new int[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                {
                    if (comparer.Compare(array1[a], array2[b]) > 0)
                        merged[i] = array2[b++];
                    else
                        merged[i] = array1[a++];
                }
                else
                {
                    if (b < array2.Length)
                        merged[i] = array2[b++];
                    else
                        merged[i] = array1[a++];
                }
            }
            return merged;
        }
        #endregion
    }
}
