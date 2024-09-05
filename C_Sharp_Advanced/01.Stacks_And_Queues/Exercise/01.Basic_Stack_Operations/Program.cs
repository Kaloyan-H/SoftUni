using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = tokens[0];
            int elementsToPop = tokens[1];
            int seekedElement = tokens[2];

            Stack<int> stack = new Stack<int>();

            foreach (var num in numbers)
            {
                stack.Push(num);
            }

            if (elementsToPop >= elementsToPush)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(seekedElement))
            {
                Console.WriteLine("true");
                return;
            }

            int smallest = int.MaxValue;

            foreach (var num in stack)
            {
                if (smallest > num)
                {
                    smallest = num;
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
