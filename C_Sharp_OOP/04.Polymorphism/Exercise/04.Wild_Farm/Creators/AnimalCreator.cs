namespace _04.Wild_Farm.Creators
{
    using Animals;
    using System;

    public class AnimalCreator : ICreator<Animal>
    {
        public Animal Create(string[] args)
        {
            string type = args[0].ToLower();
            string name = args[1];
            double weight = double.Parse(args[2]);

            switch (type)
            {
                case "owl":
                    return new Owl(name, weight, double.Parse(args[3]));
                case "hen":
                    return new Hen(name, weight, double.Parse(args[3]));
                case "mouse":
                    return new Mouse(name, weight, args[3]);
                case "dog":
                    return new Dog(name, weight, args[3]);
                case "cat":
                    return new Cat(name, weight, args[3], args[4]);
                case "tiger":
                    return new Tiger(name, weight, args[3], args[4]);
                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}
