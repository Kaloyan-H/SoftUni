using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> userRegistry = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "register":

                        if (userRegistry.Keys.Contains(tokens[1]))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {tokens[2]}");
                        }
                        else
                        {
                            userRegistry.Add(tokens[1], tokens[2]);

                            Console.WriteLine($"{tokens[1]} registered {tokens[2]} successfully");
                        }

                        break;
                    case "unregister":

                        if (!userRegistry.Keys.Contains(tokens[1]))
                        {
                            Console.WriteLine($"ERROR: user {tokens[1]} not found");
                        }
                        else
                        {
                            userRegistry.Remove(tokens[1]);

                            Console.WriteLine($"{tokens[1]} unregistered successfully");
                        }

                        break;
                }
            }

            foreach (var user in userRegistry)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
