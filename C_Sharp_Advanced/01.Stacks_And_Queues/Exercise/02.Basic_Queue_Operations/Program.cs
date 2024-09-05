using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
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

            Queue<int> stack = new Queue<int>();

            foreach (var num in numbers)
            {
                stack.Enqueue(num);
            }

            if (elementsToPop >= elementsToPush)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Dequeue();
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
