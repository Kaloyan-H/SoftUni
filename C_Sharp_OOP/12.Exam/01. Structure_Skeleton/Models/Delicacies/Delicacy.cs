namespace ChristmasPastryShop.Models.Delicacies
{
    using System;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        public Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
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
        public double Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:f2} lv";
        }
    }
}
