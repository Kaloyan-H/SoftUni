using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> greys = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> tablica = new Dictionary<string, int>()
            {
                {"Floor", 0},
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
            };

            while (whites.Count > 0 
                && greys.Count > 0)
            {
                int tempWhite = whites.Pop();
                int tempGrey = greys.Dequeue();

                if (tempWhite == tempGrey)
                {
                    int tempSum = tempWhite + tempGrey;

                    switch (tempSum)
                    {
                        case 40:

                            tablica["Sink"]++;

                            break;
                        case 50:

                            tablica["Oven"]++;

                            break;
                        case 60:

                            tablica["Countertop"]++;

                            break;
                        case 70:

                            tablica["Wall"]++;

                            break;
                        default:

                            tablica["Floor"]++;

                            break;
                    }
                }
                else
                {
                    whites.Push(tempWhite /= 2);
                    greys.Enqueue(tempGrey);
                }
            }

            tablica = tablica
                .Where(x => x.Value > 0)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"White tiles left: {(whites.Count == 0 ? "none" : string.Join(", ", whites))}\n" +
                $"Grey tiles left: {(greys.Count == 0 ? "none" : string.Join(", ", greys))}\n" +
                $"{string.Join(Environment.NewLine, tablica.Select(x => $"{x.Key}: {x.Value}"))}");
        }
    }
}
