using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> energyDrinks = new Queue<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int caffeineInBlood = 0;

            while (caffeine.Count > 0
                && energyDrinks.Count > 0)
            {
                int caffeineTemp = caffeine.Peek();
                int energyDrinkTemp = energyDrinks.Peek();

                if ((caffeineTemp * energyDrinkTemp) + caffeineInBlood <= 300)
                {
                    caffeineInBlood += caffeineTemp * energyDrinkTemp;
                    caffeine.Pop();
                    energyDrinks.Dequeue();
                }
                else
                {
                    caffeine.Pop();
                    energyDrinks.Enqueue(energyDrinks.Dequeue());
                    if (caffeineInBlood - 30 < 0)
                    {
                        caffeineInBlood = 0;
                    }
                    else
                    {
                        caffeineInBlood -= 30;
                    }
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {caffeineInBlood} mg caffeine.");
        }
    }
}
