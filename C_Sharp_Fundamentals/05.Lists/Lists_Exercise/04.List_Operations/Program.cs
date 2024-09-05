using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.List_Operations
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
                    case "Add":

                        numbers.Add(int.Parse(input[1]));

                        break;
                    case "Insert":

                        if (int.Parse(input[2]) > numbers.Count - 1 || int.Parse(input[2]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));

                        break;
                    case "Remove":

                        if (int.Parse(input[1]) > numbers.Count - 1 || int.Parse(input[1]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        numbers.RemoveAt(int.Parse(input[1]));

                        break;
                    case "Shift":

                        switch (input[1])
                        {
                            case "left":

                                for (int i = 0; i < int.Parse(input[2]); i++)
                                {
                                    numbers.Add(numbers[0]);
                                    numbers.RemoveAt(0);
                                }

                                break;
                            case "right":

                                for (int i = 0; i < int.Parse(input[2]); i++)
                                {
                                    numbers.Insert(0, numbers[numbers.Count - 1]);
                                    numbers.RemoveAt(numbers.Count - 1);
                                }

                                break;
                        }

                        break;
                    case "End":

                        Console.WriteLine(string.Join(" ", numbers));

                        return;
                }
            }
        }
    }
}
