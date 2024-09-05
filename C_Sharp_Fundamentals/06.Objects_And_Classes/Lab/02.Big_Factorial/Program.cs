using System;
using System.Numerics;

namespace _02.Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num = 1;

            int number = int.Parse(Console.ReadLine());

            for (int i = 2; i <= number; i++)
            {
                num *= i;
            }

            Console.WriteLine(num);
        }
    }
}
