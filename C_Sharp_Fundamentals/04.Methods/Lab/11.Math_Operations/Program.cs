using System;

namespace _11.Math_Operations
{
    class Program
    {
        static double Calculate(double firstNumber, double secondNumber, char oprtr)
        {
            switch (oprtr)
            {
                case '+':
                    return firstNumber + secondNumber;

                case '-':
                    return firstNumber - secondNumber;

                case '*':
                    return firstNumber * secondNumber;

                case '/':
                    return firstNumber / secondNumber;

                default:
                    return 0;
            }
        }

        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char oprtr = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(firstNumber, secondNumber, oprtr));
        }
    }
}
