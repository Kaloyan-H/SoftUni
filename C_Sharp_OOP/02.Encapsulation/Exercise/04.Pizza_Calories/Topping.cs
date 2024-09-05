using System;
using System.Collections.Generic;

namespace _04.Pizza_Calories
{
    public class Topping
    {
        private static readonly Dictionary<string, double> TYPES =
        new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };
        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        private string Type
        {
            set
            {
                if (TYPES.ContainsKey(value.ToLower())) this.type = value;
                else throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
        private double Grams
        {
            set
            {
                if (value >= 1 && value <= 50) this.grams = value;
                else throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }
        }

        public double Calories =>
            this.grams * 2 * TYPES[this.type.ToLower()];
    }
}