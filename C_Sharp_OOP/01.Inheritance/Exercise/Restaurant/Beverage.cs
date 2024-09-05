namespace Restaurant
{
    public class Beverage : Product
    {
		private double milliliters;

		public Beverage() : base() { }
		public Beverage(string name, decimal price, double milliliters) : base(name, price)
		{
			this.milliliters = milliliters;
		}

		public double Milliliters
		{
			get { return milliliters; }
			set { this.milliliters = value; }
		}
	}
}
