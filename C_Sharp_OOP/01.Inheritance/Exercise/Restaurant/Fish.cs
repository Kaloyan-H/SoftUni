namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double GRAMS = 22.00;

        public Fish() : base() { }
        public Fish(string name, decimal price)
            : base(name, price, GRAMS) { }
    }
}
