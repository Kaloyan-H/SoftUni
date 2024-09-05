using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double LARGE_HIBERNATION_PRICE = 10.50;
        public Hibernation(string name, string size)
            : base(name, size, LARGE_HIBERNATION_PRICE)
        {
        }
    }
}
