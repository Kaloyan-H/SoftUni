using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Animals
{
    using Foods;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected abstract double WeightIncreaseIncrement { get; }
        protected abstract HashSet<Type> PreferredFoods { get; }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public double Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }
        public int FoodEaten
        {
            get { return foodEaten; }
            protected set { foodEaten = value; }
        }

        public abstract void AskForFood();
        public void Eat(Food food)
        {
            if (PreferredFoods.Contains(food.GetType()))
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * WeightIncreaseIncrement;
            }
            else
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        public abstract override string ToString();
    }
}
