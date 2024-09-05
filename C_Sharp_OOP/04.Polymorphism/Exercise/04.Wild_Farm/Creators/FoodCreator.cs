namespace _04.Wild_Farm.Creators
{
    using System;
    using Foods;

    public class FoodCreator : ICreator<Food>
    {
        public Food Create(string[] args)
        {
            string type = args[0].ToLower();
            int quantity = int.Parse(args[1]);

            switch (type)
            {
                case "vegetable":
                    return new Vegetable(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                case "fruit":
                    return new Fruit(quantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
