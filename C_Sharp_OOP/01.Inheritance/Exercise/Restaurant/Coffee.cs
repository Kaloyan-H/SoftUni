namespace Restaurant
{
    public class Coffee : HotBeverage
    {
		private const double COFFEE_MILLILITERS = 50.00;
		private const decimal COFFEE_PRICE = 3.50M;
		private double caffeine;

        public Coffee() : base() { }
        public Coffee(string name, double caffeine)
            : base(name, COFFEE_PRICE, COFFEE_MILLILITERS) 
		{
			this.caffeine = caffeine;
		}

        public double CoffeeMilliliters => COFFEE_MILLILITERS;
		public decimal CoffeePrice => COFFEE_PRICE;
		public double Caffeine
		{
			get { return caffeine; }
			set { caffeine = value; }
		}
	}
}
