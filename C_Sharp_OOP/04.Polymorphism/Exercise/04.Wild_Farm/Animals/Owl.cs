namespace _04.Wild_Farm.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;

    public class Owl : Bird
    {
        private const double WEIGHT_INCREASE_INCREMENT = 0.25;
        private HashSet<Type> PREFFERED_FOODS = new HashSet<Type> 
        { 
            typeof(Meat) 
        };

        protected override double WeightIncreaseIncrement 
            => WEIGHT_INCREASE_INCREMENT;
        protected override HashSet<Type> PreferredFoods 
            => PREFFERED_FOODS;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize) { }

        public override void AskForFood()
            => Console.WriteLine("Hoot Hoot");
    }
}
