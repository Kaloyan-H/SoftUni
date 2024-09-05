using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new string[] { "|", " |", "| ", " | " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> result = new List<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                string[] temp = input[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                result.Add(string.Join(" ", temp));
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
