namespace Restaurant
{
    public class HotBeverage : Beverage
    {
        public HotBeverage() : base() { }
        public HotBeverage(string name, decimal price, double milliliters) 
            : base(name, price, milliliters) { }
    }
}
