using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceQuantities = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                string resource = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourceQuantities.Keys.Contains(resource))
                {
                    resourceQuantities.Add(resource, 0);
                }

                resourceQuantities[resource] += quantity;
            }

            foreach (var pair in resourceQuantities)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
