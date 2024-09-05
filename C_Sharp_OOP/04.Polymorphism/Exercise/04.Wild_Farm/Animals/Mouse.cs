namespace _04.Wild_Farm.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREASE_INCREMENT = 0.10;
        private HashSet<Type> PREFFERED_FOODS = new HashSet<Type>
        {
            typeof(Vegetable),
            typeof(Fruit)
        };

        protected override double WeightIncreaseIncrement 
            => WEIGHT_INCREASE_INCREMENT;
        protected override HashSet<Type> PreferredFoods 
            => PREFFERED_FOODS;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion) { }

        public override void AskForFood()
            => Console.WriteLine("Squeak");

        public override string ToString()
            => $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
