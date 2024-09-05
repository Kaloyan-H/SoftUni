namespace _04.Wild_Farm
{
    using System;
    using Creators;
    using Animals;
    using Foods;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            ICreator<Food> foodCreator = new FoodCreator();
            ICreator<Animal> animalCreator = new AnimalCreator();

            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;

                string[] animalArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Animal animal = animalCreator.Create(animalArgs);
                animals.Add(animal);
                animal.AskForFood();


                string[] foodArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Food food = foodCreator.Create(foodArgs);
                    animal.Eat(food);
                }
                catch (ArgumentException c)
                {
                    Console.WriteLine(c.Message);
                }
            }

            foreach (var animal in animals)
                Console.WriteLine(animal);
        }
    }
}
