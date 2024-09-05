namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double GRAMS = 250.00;
        private const double CALORIES = 1000.00;
        private const decimal CAKE_PRICE = 5.00M;

        public Cake() : base() { }
        public Cake(string name)
            : base(name, CAKE_PRICE, GRAMS, CALORIES) { }
    }
}
