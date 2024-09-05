using System.Collections.Generic;
using System.Reflection.Metadata;
using System;

namespace _04.Pizza_Calories
{
    public class Dough
    {
        private static readonly Dictionary<string, double> FLOUR_TYPES =
        new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1.0}
        };
        private static readonly Dictionary<string, double> BAKING_TECHNIQUES =
        new Dictionary<string, double>
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        private string FlourType
        {
            set
            {
                if (FLOUR_TYPES.ContainsKey(value.ToLower())) this.flourType = value;
                else throw new ArgumentException("Invalid type of dough.");
            }
        }
        private string BakingTechnique
        {
            set
            {
                if (BAKING_TECHNIQUES.ContainsKey(value.ToLower())) this.bakingTechnique = value;
                else throw new ArgumentException("Invalid type of dough.");
            }
        }
        private double Grams
        {
            set
            {
                if (value >= 1 && value <= 200) this.grams = value;
                else throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
        }

        public double Calories =>
            this.grams * 2 * FLOUR_TYPES[this.flourType.ToLower()] * BAKING_TECHNIQUES[this.bakingTechnique.ToLower()];
        //public double CaloriesPerGram => 
        //    2 * FLOUR_TYPES[this.flourType] * BAKING_TECHNIQUES[this.bakingTechnique];

    }
}