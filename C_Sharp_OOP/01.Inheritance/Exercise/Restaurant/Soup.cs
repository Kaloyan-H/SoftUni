namespace Restaurant
{
    public class Soup : Starter
    {
        public Soup() : base() { }
        public Soup(string name, decimal price, double grams)
            : base(name, price, grams) { }
    }
}
