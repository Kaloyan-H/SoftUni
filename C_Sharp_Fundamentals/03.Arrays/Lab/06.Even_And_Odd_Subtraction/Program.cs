using System;
using System.Linq;

namespace _06.Even_And_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumEven += numbers[i];
                }
                else
                {
                    sumOdd += numbers[i];
                }
            }

            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
