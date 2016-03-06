using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Newton
    {
        /// <summary>
        /// Возвращает корень заданной степени заданного числа с заданной точностью.
        /// </summary>
        /// <param name="number">Основание</param>
        /// <param name="power">Степень</param>
        /// <param name="accuracy">Точность</param>
        /// <param name="iterationCount">Количество итераций</param>
        /// <returns>Возвращает корень заданной степени заданного числа с заданной точностью.</returns>
        public static double Root(double number, double power, double accuracy = 0.0001, double iterationCount = 100)
        {
            if (number < 0)
                throw new ArgumentException("Невозможно извлечь корень из отрицательного числа.");
            if (power == 0)
                throw new ArgumentException("Невозможно извлечь корень 0-ой степени");
            if (accuracy == 0)
                throw new ArgumentException("Невозможно достигнуть заданной точности");
            double result = number / power;
            bool negativePower = false;
            if (power < 0)
            {
                negativePower = true;
                power = Math.Abs(power);
                result = 1 / number / power;
            }
            double temp = 0;
            while (Math.Abs(result - temp) > accuracy && iterationCount > 0)
            {
                temp = result;
                result = (1 / power) * ((power - 1) * result + number / Math.Pow(result, power - 1));
                iterationCount--;
            }
            if (negativePower)
                result = 1 / result;
            if (double.IsNaN(result) || iterationCount == 0)
                throw new Exception("Невозможно вычислить значение.");
            return result;
        }
    }
}
