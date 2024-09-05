using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> field = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < field.Count; i++)
            {
                if (field[i] == input[0])
                {
                    for (int j = i + input[1]; j >= i - input[1]; j--)
                    {
                        if (j >= 0 && j < field.Count)
                        {
                            field.RemoveAt(j);
                        }
                    }

                    i = 0;
                }
            }

            Console.WriteLine(field.Sum());
        }
    }
}
