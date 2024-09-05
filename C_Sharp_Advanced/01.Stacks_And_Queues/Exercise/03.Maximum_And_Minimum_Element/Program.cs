using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.Maximum_And_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            while (queries != 0)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "1":

                        stack.Push(int.Parse(tokens[1]));

                        break;

                    case "2":

                        stack.Pop();

                        break;

                    case "3":

                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }

                        break;

                    case "4":

                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }

                        break;
                }

                queries--;
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
