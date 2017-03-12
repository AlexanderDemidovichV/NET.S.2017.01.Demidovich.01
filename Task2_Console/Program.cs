using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
using static System.Console;

namespace Task2_Console
{
    class Program
    {
        #region Private Fields

        private static Random random = new Random();

        #endregion

        #region Public Methods

        static void Main(string[] args)
        {
            Test_FailToPassNullParameters();
            Test_ComparePerfomingWithDefaultArraySortOrderByAscending();
            Test_ComparePerfomingWithLinqOrderByDescending();
        }

        static void Test_ComparePerfomingWithDefaultArraySortOrderByAscending()
        {
            int[] unsorted_array1 = Make_Random_Array(100);
            int[] unsorted_array2 = (int[])unsorted_array1.Clone();

            unsorted_array1.Sort((x,y) => x.CompareTo(y));
            Array.Sort(unsorted_array2);

            if (unsorted_array1.SequenceEqual(unsorted_array2))
                WriteLine("Test ComparePerfomingWithDefaultArraySort - passed");
            else
                WriteLine("Test ComparePerfomingWithDefaultArraySort - failed");
        }

        static void Test_ComparePerfomingWithLinqOrderByDescending()
        {
            int[] unsorted_array1 = Make_Random_Array(100);
            int[] unsorted_array2 = (int[])unsorted_array1.Clone();

            unsorted_array2 = unsorted_array1.OrderByDescending(i => i).ToArray();
            unsorted_array1.Sort(CompareOrderByDescending);

            if (unsorted_array1.SequenceEqual(unsorted_array2))
                WriteLine("Test ComparePerfomingWithDefaultArraySort - passed");
            else
                WriteLine("Test ComparePerfomingWithDefaultArraySort - failed");
        }

        static void Test_FailToPassNullParameters()
        {
            try
            {
                Sorter.Sort(null, null);
            }
            catch
            {
                WriteLine("Test FailToPassNullParameters - passed");
                return;
            }
            WriteLine("Test FailToPassNullParameters - failed");
        }

        #endregion

        #region Private Methods

        private static int CompareOrderByDescending(int x, int y)
        {
            return y.CompareTo(x);
        }

        private static int CompareOrderByAscending(int x, int y)
        {
            return x.CompareTo(y);
        }

        private static int[] Make_Random_Array(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 101);
            }

            return array;
        }

        static private void Display_Array(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Write($"{array[i]} ");
            }
        }

        #endregion
    }
}
