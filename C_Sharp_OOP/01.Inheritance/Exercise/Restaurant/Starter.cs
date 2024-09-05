namespace Restaurant
{
    public class Starter : Food
    {
        public Starter() : base() { }
        public Starter(string name, decimal price, double grams)
            : base(name, price, grams) { }
    }
}
