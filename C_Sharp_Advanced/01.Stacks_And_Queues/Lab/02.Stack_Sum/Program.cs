using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (int item in array)
            {
                stack.Push(item);
            }

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0].ToLower() == "end")
                {
                    break;
                }

                switch (tokens[0].ToLower())
                {
                    case "add":

                        stack.Push(int.Parse(tokens[1]));
                        stack.Push(int.Parse(tokens[2]));

                        break;

                    case "remove":

                        if (stack.Count() >= int.Parse(tokens[1]))
                        {
                            for (int i = 0; i < int.Parse(tokens[1]); i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;
                }
            }

            int sum = 0;

            foreach (int number in stack)
            {
                sum += number;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
