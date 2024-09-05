using System;

namespace _03.Raiding
{
    public class ConcreteHeroCreator : HeroCreator
    {
        public override BaseHero CreateHero(string name, string type)
        {
            switch (type.ToLower())
            {
                case "druid":
                    return new Druid(name);
                case "paladin":
                    return new Paladin(name);
                case "rogue":
                    return new Rogue(name);
                case "warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
