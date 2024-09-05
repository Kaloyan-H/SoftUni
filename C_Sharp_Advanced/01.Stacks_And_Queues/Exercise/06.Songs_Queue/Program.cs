using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var song in songs)
            {
                queue.Enqueue(song);
            }

            while (queue.Count > 0)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Play":

                        queue.Dequeue();

                        break;

                    case "Add":

                        if (queue.Contains(string.Join(' ', tokens.Skip(1).ToArray())))
                        {
                            Console.WriteLine($"{string.Join(' ', tokens.Skip(1).ToArray())} is already contained!");
                        }
                        else
                        {
                            queue.Enqueue(string.Join(' ', tokens.Skip(1).ToArray()));
                        }

                        break;

                    case "Show":

                        Console.WriteLine(string.Join(", ", queue));

                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
