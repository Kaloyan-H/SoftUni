using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HeroCreator heroCreator = new ConcreteHeroCreator();

            int raidGroupSize = int.Parse(Console.ReadLine());

            List<BaseHero> raidGroup = new List<BaseHero>();

            while (raidGroup.Count < raidGroupSize)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    raidGroup.Add(heroCreator.CreateHero(heroName, heroType));
                }
                catch (ArgumentException c)
                {
                    Console.WriteLine(c.Message);
                }
            }

            int raidBossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
                Console.WriteLine(hero.CastAbility());
            
            int raidGroupPower = raidGroup.Sum(x => x.Power);

            if (raidBossPower <= raidGroupPower)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
    }
}
