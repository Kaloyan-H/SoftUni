using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Random rng = new Random();

            int tempLength = input.Count();

            for (int i = 0; i < tempLength; i++)
            {
                int tempIndex = rng.Next(0, input.Count());

                Console.WriteLine(input[tempIndex]);
                input.RemoveAt(tempIndex);
            }
        }
    }
}
