namespace _04.Wild_Farm.Foods
{
    public abstract class Food
    {
		private int quantity;

		public Food(int quantity)
		{
			Quantity = quantity;
		}

		public virtual int Quantity
		{
			get { return quantity; }
			protected set { quantity = value; }
		}
	}
}
