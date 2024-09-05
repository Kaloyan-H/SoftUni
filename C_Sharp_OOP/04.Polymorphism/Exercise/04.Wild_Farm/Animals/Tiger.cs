namespace _04.Wild_Farm.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        private const double WEIGHT_INCREASE_INCREMENT = 1.00;
        private HashSet<Type> PREFFERED_FOODS = new HashSet<Type>
        {
            typeof(Meat)
        };

        protected override double WeightIncreaseIncrement
            => WEIGHT_INCREASE_INCREMENT;
        protected override HashSet<Type> PreferredFoods
            => PREFFERED_FOODS;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        public override void AskForFood()
            => Console.WriteLine("ROAR!!!");
    }
}
