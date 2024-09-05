﻿namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int POWER = 80;

        public Rogue(string name)
            : base(name, POWER) { }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
