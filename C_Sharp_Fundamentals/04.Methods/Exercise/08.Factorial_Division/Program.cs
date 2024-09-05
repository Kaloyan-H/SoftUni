using System;

namespace _08.Factorial_Division
{
    class Program
    {
        static double Factorial(int number)
        {
            double result = 1;

            while (number != 1)
            {
                result *= number;
                number--;
            }

            return result;
        }

        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double result1 = Factorial(num1);
            double result2 = Factorial(num2);

            Console.WriteLine($"{result1 / result2:f2}");
        }
    }
}
