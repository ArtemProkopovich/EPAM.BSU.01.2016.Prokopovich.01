using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class ArraySort
    {
        /// <summary>
        /// Соритрует двумерный массив по заданной функции значения и заданному компаратору.
        /// </summary>
        /// <param name="array">Массив чисел</param>
        /// <param name="keyFunc">Функция вычисления значения ключей для строк массива</param>
        /// <param name="comparer">Компаратор по значениям ключей</param>
        public static void Sort<T1, T2>(T1[][] array, Func<T1[], T2> keyFunc, Comparer<T2> comparer)
        {
            T2[] valueArray = new T2[array.Count()];
            for (int i = 0; i < valueArray.Length; i++)
                valueArray[i] = keyFunc(array[i]);

            for (int i = 0; i < valueArray.Length - 1; i++)
            {
                for (int j = i + 1; j < valueArray.Length; j++)
                {
                    if (comparer.Compare(valueArray[j], valueArray[i]) < 0)
                    {
                        Swap(ref array[i],ref array[j]);
                        Swap(ref valueArray[i],ref valueArray[j]);
                    }
                }
            }
        }

        private static void Swap<T>(ref T obj1, ref T obj2)
        {
            T temp = obj2;
            obj2 = obj1;
            obj1 = temp;
        }
    }
}
