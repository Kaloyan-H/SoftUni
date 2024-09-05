using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (input[0])
                {
                    case "end":

                        Console.WriteLine(string.Join(" ", numbers));

                        return;
                    case "Delete":

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == int.Parse(input[1]))
                            {
                                numbers.RemoveAt(i);
                            }
                        }

                        break;
                    case "Insert":

                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));

                        break;
                }
            }
        }
    }
}
