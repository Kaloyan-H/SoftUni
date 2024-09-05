namespace Restaurant
{
    public class Dessert : Food
    {
		private double calories;

		public Dessert() : base() { }
		public Dessert(string name, decimal price, double grams, double calories) 
			: base(name, price, grams)
		{
			this.calories = calories;
		}

		public double Calories
		{
			get { return calories; }
			set { calories = value; }
		}
	}
}
