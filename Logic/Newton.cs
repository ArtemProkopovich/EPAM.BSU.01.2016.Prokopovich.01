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
        /// <returns>Возвращает корень заданной степени заданного числа с заданной точностью.</returns>
        public static double Root(double number, int power, double accuracy = 0.00001)
        {
            if (number < 0 && power % 2 == 0)
                throw new ArgumentException("Невозможно извлечь корень четной степени из отрицательного числа.");
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
            }
            double temp = 0;
            while (Math.Abs(result - temp) > accuracy)
            {
                temp = result;
                result = (1.0 / power) * ((power - 1.0) * result + number / Power(result, power - 1));
            }
            if (negativePower)
                result = 1.0 / result;
            if (double.IsNaN(result) || double.IsNegativeInfinity(result) || double.IsPositiveInfinity(result))
                throw new Exception("Невозможно вычислить значение.");
            return result;
        }


        private static double Power(double number, int power)
        {
            double result = 1;
            while (power != 0)
            {
                if (power % 2 == 1)
                    result *= number;
                number *= number;
                power = power / 2;
            }
            return result;
        }
    }
}
