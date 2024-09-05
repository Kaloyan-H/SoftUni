using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ",
                list
                .Where(i => i % number != 0)
                .Reverse()));
        }
    }
}
