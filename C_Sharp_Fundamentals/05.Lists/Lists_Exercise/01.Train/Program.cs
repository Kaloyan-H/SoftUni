using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "end")
                {
                    break;
                }

                switch (input[0])
                {
                    case "Add":

                        wagons.Add(int.Parse(input[1]));

                        break;
                    default:

                        for (int i = 0; i < wagons.Count; i++)
                        {
                            if (wagons[i] + int.Parse(input[0]) <= capacity)
                            {
                                wagons[i] += int.Parse(input[0]);
                                break;
                            }
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
