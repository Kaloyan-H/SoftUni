using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while(true)
            {
                string input = Console.ReadLine();

                if (input == "Beast!")
                {
                    foreach (var animal in animals)
                    {
                        Console.WriteLine(animal);
                        Console.WriteLine(animal.ProduceSound());
                    }

                    return;
                }


                string animalType = input.ToLower();
                string[] properties = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (properties.Length != 3)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string name = properties[0];
                int age = int.Parse(properties[1]);
                string gender = properties[2];

                if ((animalType != "dog" 
                    && animalType != "cat" 
                    && animalType != "frog"
                    && animalType != "kitten"
                    && animalType != "tomcat")
                    || age <= 0 
                    || (gender != "Female" && gender != "Male"))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (animalType)
                {
                    case "dog":

                        animals.Add(new Dog(
                            name,
                            age,
                            gender));

                        break;
                    case "cat":

                        animals.Add(new Cat(
                            name,
                            age,
                            gender));

                        break;
                    case "frog":

                        animals.Add(new Frog(
                            name,
                            age,
                            gender));

                        break;
                    case "kitten":

                        animals.Add(new Kitten(
                            name,
                            age));

                        break;
                    case "tomcat":

                        animals.Add(new Tomcat(
                            name,
                            age));

                        break;
                }
            }
        }
    }
}
