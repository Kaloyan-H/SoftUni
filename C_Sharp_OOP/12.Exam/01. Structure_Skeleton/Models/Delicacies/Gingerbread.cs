namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        //gignerbreadPrice mistake!
        private const double GINGERBREAD_PRICE = 4.00;

        public Gingerbread(string delicacyName)
            : base(delicacyName, GINGERBREAD_PRICE)
        {
        }
    }
}
