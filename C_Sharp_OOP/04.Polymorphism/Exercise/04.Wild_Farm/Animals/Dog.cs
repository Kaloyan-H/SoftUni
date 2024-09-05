namespace _04.Wild_Farm.Animals
{
    using Foods;
    using System.Collections.Generic;
    using System;

    public class Dog : Mammal
    {
        private const double WEIGHT_INCREASE_INCREMENT = 0.40;
        private HashSet<Type> PREFFERED_FOODS = new HashSet<Type>
        {
            typeof(Meat),
        };

        protected override double WeightIncreaseIncrement
            => WEIGHT_INCREASE_INCREMENT;
        protected override HashSet<Type> PreferredFoods
            => PREFFERED_FOODS;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        public override void AskForFood()
            => Console.WriteLine("Woof!");

        public override string ToString()
            => $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
