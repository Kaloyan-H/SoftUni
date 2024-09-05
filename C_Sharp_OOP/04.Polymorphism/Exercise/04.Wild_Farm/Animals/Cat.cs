namespace _04.Wild_Farm.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;

    public class Cat : Feline
    {
        private const double WEIGHT_INCREASE_INCREMENT = 0.30;
        private HashSet<Type> PREFFERED_FOODS = new HashSet<Type>
        {
            typeof(Vegetable),
            typeof(Meat)
        };

        protected override double WeightIncreaseIncrement
            => WEIGHT_INCREASE_INCREMENT;
        protected override HashSet<Type> PreferredFoods
            => PREFFERED_FOODS;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        public override void AskForFood()
            => Console.WriteLine("Meow");
    }
}
