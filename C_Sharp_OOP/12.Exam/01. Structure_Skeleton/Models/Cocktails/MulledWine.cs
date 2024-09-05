namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double LARGE_MULLED_WINE_PRICE = 13.50;
        public MulledWine(string name, string size)
            : base(name, size, LARGE_MULLED_WINE_PRICE)
        {
        }
    }
}
