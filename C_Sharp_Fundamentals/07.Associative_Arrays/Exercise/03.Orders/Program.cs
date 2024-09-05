using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Orders
{
    class PriceAndQuantity
    {
        public PriceAndQuantity() { }
        public PriceAndQuantity(decimal price, int quantity)
        {
            this.Price = price;
            this.Quantity = quantity;
        }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PriceAndQuantity> productsList = new Dictionary<string, PriceAndQuantity>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string product = tokens[0];

                PriceAndQuantity priceAndQuantity = new PriceAndQuantity(
                    decimal.Parse(tokens[1]),
                    int.Parse(tokens[2]));

                if (!productsList.Keys.Contains(product))
                {
                    productsList.Add(product, new PriceAndQuantity(0, 0));
                }

                productsList[product].Price = priceAndQuantity.Price;
                productsList[product].Quantity += priceAndQuantity.Quantity;
            }

            foreach (var product in productsList)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Price * product.Value.Quantity:f2}");
            }
        }
    }
}
