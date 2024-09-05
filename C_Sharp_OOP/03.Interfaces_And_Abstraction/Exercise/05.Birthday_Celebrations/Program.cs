using System;
using System.Collections.Generic;

namespace _05.Birthday_Celebrations
{
    using Classes;
    using Interfaces;

    internal class Program
    {
        static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] args = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "Citizen")
                {
                    if (args.Length != 5) continue;

                    birthables.Add(new Citizen(args[1], int.Parse(args[2]), args[3], args[4]));
                }
                else if (args[0] == "Pet")
                {
                    if (args.Length != 3) continue;

                    birthables.Add(new Pet(args[1], args[2]));
                }
            }

            string yearKey = Console.ReadLine();

            foreach (var birthable in birthables)
            {
                if (birthable.BirthYear == yearKey)
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
