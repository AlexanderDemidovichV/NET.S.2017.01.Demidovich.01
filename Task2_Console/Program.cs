using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2_Console
{
    class Program
    {
        public class ReverseComparer : IComparer
        {
            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            public int Compare(Object x, Object y)
            {
                return (new CaseInsensitiveComparer()).Compare(y, x);
            }
        }

        public class DirectComparer : IComparer
        {
            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            public int Compare(Object x, Object y)
            {
                return (new CaseInsensitiveComparer()).Compare(x, y);
            }
        }

        static void Main(string[] args)
        {
            int[] unsorted_array = { 3, 6, 1, 7, 3, 9 };
            ReverseComparer reverse_comparer = new ReverseComparer();
            DirectComparer direct_comparer = new DirectComparer();

            Display_Array(unsorted_array);

            Console.WriteLine();

            Sorter.Sort(unsorted_array, direct_comparer);

            Display_Array(unsorted_array);
        }

        static private void Display_Array(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
