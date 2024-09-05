using System;
using System.Collections.Generic;

namespace _07.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int unluckyNumber = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            foreach (string kid in kids)
            {
                queue.Enqueue(kid);
            }

            int counter = 0;

            while (queue.Count > 1)
            {
                counter++;

                if (counter % unluckyNumber == 0)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}"); 
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
