namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using Contracts;
    using Cocktails.Contracts;
    using Delicacies.Contracts;
    using Repositories.Contracts;
    using static Utilities.Messages.ExceptionMessages;
    using System.Text;
    using Repositories;

    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        private Booth()
        {
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
        }
        public Booth(int boothId, int capacity)
            : this()
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
        }

        public int BoothId
        {
            get { return this.boothId; }
            private set { this.boothId = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(CapacityLessThanOne);
                }
                this.capacity = value; 
            }
        }
        public IRepository<IDelicacy> DelicacyMenu
        {
            get { return this.delicacyMenu; }
            //private set { this.delicacyMenu = value; } //Maybe optional
        }
        public IRepository<ICocktail> CocktailMenu
        {
            get { return this.cocktailMenu; }
            //private set { this.cocktailMenu = value; } //Maybe optional
        }
        public double CurrentBill
        {
            get { return this.currentBill; }
            private set { this.currentBill = value; }
        }
        public double Turnover
        {
            get { return this.turnover; }
            private set { this.turnover = value; }
        }
        public bool IsReserved
        {
            get { return this.isReserved; }
            private set { this.isReserved = value; }
        }

        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }
        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }
        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"Booth: {this.BoothId}\n" +
                $"Capacity: {this.Capacity}\n" +
                $"Turnover: {this.Turnover:f2} lv");

            sb.AppendLine("-Cocktail menu:");
            foreach (var cocktail in this.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().Trim();
        }
    }
}
