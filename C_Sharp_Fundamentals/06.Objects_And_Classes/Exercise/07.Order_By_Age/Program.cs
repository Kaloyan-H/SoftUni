using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Order_By_Age
{
    class Person
    {
        public Person() { }
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id; ;
            this.Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public void Print()
        {
            Console.WriteLine($"{this.Name} with ID: {this.ID} is {this.Age} years old.");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                bool flagAlreadyExists = false;
                int counter = 0;

                foreach (var person in people)
                {
                    if (tokens[1] == person.ID)
                    {
                        flagAlreadyExists = true;
                        break;
                    }

                    counter++;
                }

                if (flagAlreadyExists == true)
                {
                    people.RemoveAt(counter);

                    people.Insert(counter, new Person(
                        tokens[0],
                        tokens[1],
                        int.Parse(tokens[2])));
                }
                else
                {
                    people.Add(new Person(
                        tokens[0],
                        tokens[1],
                        int.Parse(tokens[2])));
                }
            }

            people = people
                .OrderBy(person => person.Age)
                .ToList();

            foreach (var person in people)
            {
                person.Print();
            }
        }
    }
}
