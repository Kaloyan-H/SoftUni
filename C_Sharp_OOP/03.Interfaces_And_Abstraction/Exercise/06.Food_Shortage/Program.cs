namespace _06.Food_Shortage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Classes;

    public class Program
    {
        static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Person[] people = new Person[numberOfPeople];

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] args = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 4)
                {
                    people[i] = new Citizen(
                        args[0],
                        int.Parse(args[1]),
                        args[2],
                        args[3]);
                }
                else if (args.Length == 3)
                {
                    people[i] = new Rebel(
                        args[0],
                        int.Parse(args[1]),
                        args[2]);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                Person tempPerson = Array.Find(people, x => x.Name == input);

                if (tempPerson != null)
                {
                    tempPerson.BuyFood();
                }
            }

            Console.WriteLine(people.Sum(x => x.Food));
        }
    }
}
