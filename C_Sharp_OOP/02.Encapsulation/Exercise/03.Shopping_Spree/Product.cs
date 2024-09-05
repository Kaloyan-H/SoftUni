using System;

namespace _03.Shopping_Spree
{
    public class Product
    {
		private string name;
		private decimal cost;

		public Product(string name, decimal cost)
		{
			this.Name = name;
			this.Cost = cost;
		}

		public string Name
		{
			get { return this.name; }
			private set 
			{
				if (value != string.Empty
                    && !string.IsNullOrEmpty(value)
                    && !string.IsNullOrWhiteSpace(value)) this.name = value;
                else throw new ArgumentException("Name cannot be empty");
            }
		}
		public decimal Cost
		{
			get { return this.cost; }
			private set 
			{
				if (value >= 0) this.cost = value;
                else throw new ArgumentException("Money cannot be negative");
            }
		}

		public override string ToString()
		{
			return this.Name;
		}

	}
}
