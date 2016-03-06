using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ArraySort
    {
        public enum OrderBy { increase, decrease }
        public enum Condition { Sum, Max, Min }

        private delegate int? Function(int[] array);
        private delegate bool Order(int? num1, int? num2);

        /// <summary>
        /// Сортирует двумерный массив по указанному признаку в указанном порядке.
        /// </summary>
        /// <param name="array">Массив целых чисел.</param>
        /// <param name="condition">Условие сортировки.</param>
        /// <param name="order">Порядок соритровки.</param>
        public void Sort(int[][] array, Condition condition, OrderBy order)
        {
            if (array == null)
                return;
            if (array.Count() == 0)
                return;
            Order orderFunc;
            if (order == OrderBy.increase)
                orderFunc = IsSmaller;
            else
                orderFunc = IsLarger;
            switch (condition)
            {
                case Condition.Sum: Sort(array, Sum, orderFunc); break;
                case Condition.Max: Sort(array, Max, orderFunc); break;
                case Condition.Min: Sort(array, Min, orderFunc); break;
            }
        }

        /// <summary>
        /// Соритрует двумерный массив по заданной функции значения и заданной функции упорядочивания
        /// </summary>
        /// <param name="array">Массив чисел</param>
        /// <param name="func">Функция значения</param>
        /// <param name="order">Функция упорядочивания</param>
        private void Sort(int[][] array, Function func, Order order)
        {
            int?[] valueArray = new int?[array.Count()];
            for (int i = 0; i < valueArray.Length; i++)
                valueArray[i] = func(array[i]);

            for (int i = 0; i < valueArray.Length - 1; i++)
            {
                for (int j = i + 1; j < valueArray.Length; j++)
                {
                    if (order(valueArray[j], valueArray[i]))
                    {
                        int[] tempArray = array[i];
                        array[i] = array[j];
                        array[j] = tempArray;

                        int? temp = valueArray[i];
                        valueArray[i] = valueArray[j];
                        valueArray[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает минимальное значение в целочисленном массиве.
        /// </summary>
        /// <param name="array">Массив целых чисел</param>
        /// <returns></returns>
        public int? Min(int[] array)
        {
            if (array == null)
                return null;

            int temp = array.Length == 0 ? int.MinValue : int.MaxValue;
            foreach (int i in array)
                if (i < temp)
                    temp = i;
            return temp;
        }

        /// <summary>
        /// Возвращает максимальное значение в массиве
        /// </summary>
        /// <param name="array">Массив целых чисел</param>
        /// <returns></returns>
        public int? Max(int[] array)
        {
            if (array == null)
                return null;

            int temp = array.Length == 0 ? 0 : int.MinValue;
            foreach (int i in array)
                if (i > temp)
                    temp = i;
            return temp;
        }

        /// <summary>
        /// Возвращает сумму элементов в массиве
        /// </summary>
        /// <param name="array">Массив целых чисел</param>
        /// <returns></returns>
        public int? Sum(int[] array)
        {
            if (array == null)
                return null;

            int temp = 0;
            foreach (int i in array)
                temp += i;
            return temp;
        }

        private bool IsLarger(int? num1, int? num2)
        {
            if (num1 == null && num2 == null)
                return false;
            else if (num1 == null)
                return false;
            else if (num2 == null)
                return true;
            else
                return num1 > num2;

        }

        private bool IsSmaller(int? num1, int? num2)
        {
            if (num1 == null && num2 == null)
                return false;
            else if (num1 == null)
                return true;
            else if (num2 == null)
                return false;
            else
                return num1 < num2;
        }
    }
}
