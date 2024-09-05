using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();

            foreach (var order in orders)
            {
                queue.Enqueue(order);
            }

            Console.WriteLine(queue.Max());

            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine($"Orders complete");
                    break;
                }

                if (foodQuantity < queue.Peek())
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
                    break;
                }

                foodQuantity -= queue.Dequeue();
            }
        }
    }
}
