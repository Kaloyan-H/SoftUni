namespace Restaurant
{
    public class Product
    {
		private string name;
		private decimal price;

		public Product() { }
		public Product(string name, decimal price)
		{
			this.name = name;
			this.price = price;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	}
}
