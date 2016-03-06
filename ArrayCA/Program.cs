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
            if (random.Next(10) == 0)
                return null;
            int[][] result = new int[random.Next(10)][];
            for (int i = 0; i < result.Count(); i++)
            {
                if (random.Next(5) != 0)
                {
                    result[i] = new int[random.Next(10)];
                    for (int j = 0; j < result[i].Length; j++)
                        result[i][j] = random.Next(10);
                }
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
            ArraySort sort = new ArraySort();
            for (int i = 0; i < 10; i++)
            {
                array = RandomArray();
                Console.WriteLine("Исходный массив: ");
                Console.WriteLine(PrintArray(array));

                ArraySort.Condition cond = (ArraySort.Condition)random.Next(3);
                ArraySort.OrderBy order =  (ArraySort.OrderBy)random.Next(2);
                sort.Sort(array, cond, order);
                Console.WriteLine($"Отсортированный массив по {cond} и по {order}: ");
                Console.WriteLine(PrintArray(array));
            }
            Console.ReadLine();
        }
    }
}
