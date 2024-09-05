namespace ChristmasPastryShop.Models.Cocktails
{
    using System;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(NameNullOrWhitespace);
                }
                this.name = value;
            }
        }

        public string Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }

        public double Price
        {
            get { return this.price; }
            private set
            {
                switch (size)
                {
                    case "Small":
                        this.price = value / 3;
                        break;
                    case "Middle":
                        this.price = value * 2 / 3;
                        break;
                    case "Large":
                        this.price = value;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}
