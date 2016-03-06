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
                power = Abs(power);
            }
            double temp = 0;
            while (Abs(result - temp) > accuracy && iterationCount > 0)
            {
                temp = result;
                result = (1 / power) * ((power - 1) * result + number / Power(result, power - 1));
                iterationCount--;
            }
            if (negativePower)
                result = 1 / result;
            if (double.IsNaN(result) || iterationCount == 0)
                throw new Exception("Невозможно вычислить значение.");
            return result;
        }

        private static double Abs(double number)
        {
            if (number < 0)
                return -number;
            else
                return number;
        }

        private static double Power(double number, double degree, double accuracy = 0.0000001)
        {
            bool reverseNumber = false;
            if (number > 1)
            {
                reverseNumber = true;
                number = 1 / number;
            }
            number = number - 1;
            double result = 1 + degree * number;
            double temp = 0;
            int count = 2;
            while (Abs(result - temp) > accuracy && count < 15)
            {
                temp = result;
                result += NegFactorial(degree, count) / Factorial(count) * IntPower(number, count);
                count++;
            }
            if (reverseNumber)
                result =  1 / result;
            return Abs(result);
        }

        private static double IntPower(double number, int power)
        {
            double result = 1;
            while (power > 0)
            {
                if (power % 2 == 1)
                    result *= number;
                number *= number;
                power = power / 2;
            }
            return result;

        }

        private static double NegFactorial(double number, int count)
        {
            double result = 1;
            for (int i = 0; i < count; i++)
            {
                result *= number - i;
            }
            return result;
        }

        private static double Factorial(int number)
        {
            double result = 1;
            for (int i = 1; i <= number; i++)
                result *= i;
            return result;
        }
    }
}
