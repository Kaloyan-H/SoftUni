using System;
using System.Collections.Generic;

namespace _03.Shopping_Spree
{
    public class Person
    {
		private string name;
		private decimal money;
		private List<Product> products;

		public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			this.Products = new List<Product>();
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
		public decimal Money
		{
			get { return this.money; }
			private set 
			{
				if (value >= 0) this.money = value;
				else throw new ArgumentException("Money cannot be negative");
            }
        }
		public List<Product> Products
		{
			get { return this.products; }
			private set { this.products = value; }
		}

		public void Buy(Product product)
		{
			if (product.Cost <= this.Money)
			{
				this.Money -= product.Cost;
				this.Products.Add(product);
				Console.WriteLine($"{this.Name} bought {product.Name}");
			}
			else
			{
				Console.WriteLine($"{this.Name} can't afford {product.Name}");
			}
		}

		public override string ToString()
		{
			return $"{this.Name} - {(this.Products.Count > 0 ? string.Join(", ", this.Products) : "Nothing bought")}";
		}

	}
}
