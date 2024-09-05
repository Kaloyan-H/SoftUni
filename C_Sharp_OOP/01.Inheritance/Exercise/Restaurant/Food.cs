namespace Restaurant
{
    public class Food : Product
    {
		private double grams;

		public Food() : base() { }
		public Food(string name, decimal price, double grams) : base(name, price)
		{
			this.grams = grams;
		}

		public double Grams
		{
			get { return grams; }
			set { grams = value; }
		}
	}
}
