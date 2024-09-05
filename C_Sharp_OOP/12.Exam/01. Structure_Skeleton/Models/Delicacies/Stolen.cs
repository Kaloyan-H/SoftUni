namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double STOLEN_PRICE = 3.50;

        public Stolen(string delicacyName)
            : base(delicacyName, STOLEN_PRICE)
        {
        }
    }
}
