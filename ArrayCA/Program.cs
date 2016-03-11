using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ArrayCA
{
    class Program
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

        static string PrintArray(int[][] array)
        {
            if (array == null)
                return "Null array";
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (int[] arr in array)
            {
                builder.Append($"{i}: ");
                if (arr == null)
                    builder.Append("null");
                else
                {
                    foreach (int num in arr)
                    {
                        builder.Append($"{num}  ");
                    }
                }
                builder.Append(Environment.NewLine);
                i++;
            }
            return builder.ToString();            
        }

        static void Main(string[] args)
        {
            int[][] array = null;
            for (int i = 0; i < 10; i++)
            {
                array = RandomArray();
                Console.WriteLine("Исходный массив: ");
                Console.WriteLine(PrintArray(array));
                ArraySort.Sort(array, e => e.Max(), Comparer<int>.Default);
                Console.WriteLine($"Отсортированный массив по максимуму и по дефолту: ");
                Console.WriteLine(PrintArray(array));
            }
            Console.ReadLine();
        }
    }
}
