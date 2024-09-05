using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
            }

            string[] orderedSet = set.OrderBy(x => x).ToArray();

            Console.WriteLine(string.Join(' ', orderedSet));
        }
    }
}
