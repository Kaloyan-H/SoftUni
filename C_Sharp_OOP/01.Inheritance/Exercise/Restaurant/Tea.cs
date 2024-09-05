namespace Restaurant
{
    public class Tea : HotBeverage
    {
        public Tea() : base() { }
        public Tea(string name, decimal price, double milliliters)
            : base(name, price, milliliters) { }
    }
}
