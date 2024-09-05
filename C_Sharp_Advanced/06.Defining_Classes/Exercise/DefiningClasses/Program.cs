using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                bool flag = false;

                foreach (var trainer in trainers)
                {
                    if (trainer.Name == tokens[0])
                    {
                        trainer.Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    trainers.Add(new Trainer(tokens[0], new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3]))));
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    bool flag = false;
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == input)
                        {
                            flag = true;
                        }
                    }

                    if (flag)
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }

                    trainer.Pokemons = trainer.Pokemons
                        .Where(x => x.Health > 0)
                        .ToList();
                }
            }

            Trainer[] orderedTrainers = trainers
                .OrderByDescending(x => x.NumberOfBadges)
                .ToArray();

            foreach (var trainer in orderedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
