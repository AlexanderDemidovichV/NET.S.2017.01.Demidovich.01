using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.NUnitTests
{
    class MergeSorterTests
    {
        private static readonly Random Random = new Random();

        public IEnumerable<TestCaseData> TestFailtoPassNullParams
        {
            get
            {
                yield return new TestCaseData().Throws(typeof(ArgumentNullException));
                yield return new TestCaseData().Throws(typeof(ArgumentNullException));
            }
        }

        [Test, TestCaseSource("TestFailtoPassNullParams")]
        public static void TestFailToPassNullParameters()
        {
            Sorter.Sort(null, null);
        }

        public IEnumerable<TestCaseData> TestCompareOrderByAscending
        {
            get
            {
                yield return new TestCaseData();
                yield return new TestCaseData();
            }
        }

        [Test, TestCaseSource("TestCompareOrderByAscending")]
        public static void TestComparePerformingWithDefaultArraySortOrderByAscending()
        {
            int[] unsortedArray1 = Make_Random_Array(100);
            int[] unsortedArray2 = (int[])unsortedArray1.Clone();

            unsortedArray1.Sort((x, y) => x.CompareTo(y));

            Array.Sort(unsortedArray2);

            Assert.AreEqual(unsortedArray1, unsortedArray2);
        }

        public IEnumerable<TestCaseData> TestCompareOrderByDescending
        {
            get
            {
                yield return new TestCaseData();
                yield return new TestCaseData();
            }
        }

        [Test, TestCaseSource("TestCompareOrderByDescending")]
        public static void TestComparePerformingWithLinqExpressionOrderByDescending()
        {
            int[] unsortedArray1 = Make_Random_Array(100);
            int[] unsortedArray2 = (int[])unsortedArray1.Clone();

            unsortedArray1.Sort(CompareOrderByDescending);

            unsortedArray2 = unsortedArray1.OrderByDescending(i => i).ToArray();

            Assert.AreEqual(unsortedArray1, unsortedArray2);
        }

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
                array[i] = Random.Next(1, 101);
            }

            return array;
        }
    }
}
