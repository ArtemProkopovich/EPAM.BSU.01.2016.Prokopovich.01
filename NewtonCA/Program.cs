using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace NewtonCA
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "y";
            while (key != "n")
            {
                try
                {
                    Console.WriteLine("Введите число: ");
                    double number = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите степень: ");
                    double power = double.Parse(Console.ReadLine());
                    double result = Newton.Root(number, power);
                    Console.WriteLine($"Метод Ньютона: Корень числа {number} степени {power} равен {result}");
                    Console.WriteLine($"Math.Pow: Корень числа {number} степени {power} равен {Math.Pow(number, 1 / power)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Хотите повторить (y/n):");
                key = Console.ReadLine();
            }
        }
    }
}
