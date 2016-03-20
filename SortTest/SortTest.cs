using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic;

namespace SortTest
{
    [TestFixture]
    public class SortTest
    {
        static Random random = new Random();
        static int[][] RandomArray()
        {
            int[][] result = new int[random.Next(1, 10)][];
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = new int[random.Next(1, 10)];
                for (int j = 0; j < result[i].Length; j++)
                    result[i][j] = random.Next(20);
            }
            return result;
        }

        static int[][] CopyArray(int[][] array)
        {
            int[][] result = new int[array.Count()][];
            for (int i = 0; i < array.Count(); i++)
            {
                result[i] = new int[array[i].Length];
                for (int j = 0; j < result[i].Length; j++)
                    result[i][j] = array[i][j];
            }
            return result;
        }

        [Test]
        public void Sort_TestMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                int[][] array1 = RandomArray();
                int[][] array2 = CopyArray(array1);
                Comparer<int> c = Comparer<int>.Create((e, p) =>
                {
                    if (e < p) return -1;
                    if (e == p) return 0;
                    return 1;
                });
                ArraySort.Sort(array1, new AbsMaxArray());
                ArraySort.Sort(array2, e => e.Max(), c);
                Assert.AreEqual(array1, array2);

                array1 = RandomArray();
                array2 = CopyArray(array1);
                ArraySort.Sort(array1, new SumArray());
                ArraySort.Sort(array2, e => e.Sum(), c);
                Assert.AreEqual(array1, array2);
            }
        }

        public class AbsMaxArray : IArrayKey<int, int>
        {
            public int GetKey(int[] array)
            {
                int index = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (Math.Abs(array[i]) > Math.Abs(array[index]))
                        index = i;
                }
                return array[index];
            }
        }

        public class SumArray : IArrayKey<int, int>
        {
            public int GetKey(int[] array)
            {
                int result = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    result += array[i];
                }
                return result;
            }
        }
    }
}
