namespace _04.Wild_Farm.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        private const double WEIGHT_INCREASE_INCREMENT = 0.35;
        private HashSet<Type> PREFFERED_FOODS = new HashSet<Type> 
        {
            typeof(Meat),
            typeof(Vegetable),
            typeof(Seeds),
            typeof(Fruit)
        };

        protected override double WeightIncreaseIncrement 
            => WEIGHT_INCREASE_INCREMENT;
        protected override HashSet<Type> PreferredFoods 
            => PREFFERED_FOODS;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }


        public override void AskForFood()
            => Console.WriteLine("Cluck");
    }
}
