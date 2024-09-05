using System;

namespace _03.Calculations
{
    class Program
    {
        static void Addition(int n, int m)
        {
            Console.WriteLine(n + m);
        }

        static void Multiplication(int n, int m)
        {
            Console.WriteLine(n * m);
        }

        static void Subtraction(int n, int m)
        {
            Console.WriteLine(n - m);
        }

        static void Division(int n, int m)
        {
            Console.WriteLine(n / m);
        }
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    Addition(firstNumber, secondNumber);
                    break;
                case "multiply":
                    Multiplication(firstNumber, secondNumber);
                    break;
                case "subtract":
                    Subtraction(firstNumber, secondNumber);
                    break;
                case "divide":
                    Division(firstNumber, secondNumber);
                    break;
            }
        }
    }
}
