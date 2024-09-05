namespace Restaurant
{
    public class MainDish : Food
    {
        public MainDish() : base() { }
        public MainDish(string name, decimal price, double grams) 
            : base(name, price, grams) { }
    }
}
