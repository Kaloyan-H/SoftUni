using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> output = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                bool flag = true;

                for (int j = 0; j < dividers.Length; j++)
                {
                    if (i % dividers[j] != 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    output.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
