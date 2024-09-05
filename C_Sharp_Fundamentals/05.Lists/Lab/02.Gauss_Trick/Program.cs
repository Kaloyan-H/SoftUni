using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i != numbers.Count - 1)
                {
                    numbers[i] += numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
