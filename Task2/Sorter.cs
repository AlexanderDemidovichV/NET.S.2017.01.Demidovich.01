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
            Array.Sort(array, comparer);
        }
        #endregion
    }
}
