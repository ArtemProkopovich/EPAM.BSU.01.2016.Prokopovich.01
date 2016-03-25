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
        public static void Sort<T1, T2>(T1[][] array, Func<T1[], T1[], int> func)
        {
            for (int i = 0; i < array.Count() - 1; i++)
            {
                for (int j = i + 1; j < array.Count(); j++)
                {
                    if (func(array[j], array[i]) < 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Соритрует двумерный массив по заданной функции значения и заданному компаратору.
        /// </summary>
        /// <param name="array">Массив чисел.</param>
        /// <param name="keyFunc">Интрфейс вычисляющий значения ключей для строк массива.</param>
        public static void Sort<T>(T[][] array, IArrayKey<T> keyFunc)
        {
            for (int i = 0; i < array.Count() - 1; i++)
            {
                for (int j = i + 1; j < array.Count(); j++)
                {
                    if (keyFunc.CompareTo(array[j], array[i]) < 0)
                    {
                        Swap(ref array[i], ref array[j]);
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
