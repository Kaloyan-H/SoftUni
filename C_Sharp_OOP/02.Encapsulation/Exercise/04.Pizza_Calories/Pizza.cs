using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System;

namespace _04.Pizza_Calories
{
    public class Pizza
    {
		private string name;
		private Dough dough;
		private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

		public string Name
		{
			get { return this.name; }
			private set 
            {
                if (!(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    && value.Length <= 15) this.name = value;
                else throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
		}
        public Dough Dough
        {
            private get { return this.dough; }
            set { this.dough = value; }
        }
        public uint ToppingsCount => (uint)this.toppings.Count;
        public double Calories => this.dough.Calories + this.toppings.Sum(p => p.Calories);
        private List<Topping> Toppings
        {
            get { return this.toppings; }
            set { this.toppings = value; }
        }

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount + 1 <= 10) 
                this.Toppings.Add(topping);
            else throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:f2} Calories.";
        }
    }
}
