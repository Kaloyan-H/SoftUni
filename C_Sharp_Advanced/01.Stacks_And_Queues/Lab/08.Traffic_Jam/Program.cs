using System;
using System.Collections.Generic;

namespace _08.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightCapacity = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            int carCounter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine($"{carCounter} cars passed the crossroads.");
                    break;
                }

                int tempCounter = greenLightCapacity;

                if (input == "green")
                {
                    while (queue.Count > 0 && tempCounter > 0)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        carCounter++;
                        tempCounter--;
                    }
                    continue;
                }

                queue.Enqueue(input);
            }
        }
    }
}
