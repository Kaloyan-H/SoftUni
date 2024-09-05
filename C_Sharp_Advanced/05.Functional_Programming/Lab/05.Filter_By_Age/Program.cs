using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Person> people = ReadPeople(count);

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Action<Person> printer = CreatePrinter(format);

            PrintFilteredPeople(people, filter, printer);
        }

        public class Person
        {
            public Person() { }

            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static List<Person> ReadPeople(int count)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(input[0], int.Parse(input[1])));
            }

            return people;
        }

        public static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "older")
            {
                return p => p.Age >= ageThreshold;
            }
            else
            {
                return p => p.Age < ageThreshold;
            }
        }

        public static Action<Person> CreatePrinter(string format)
        {
            Action<Person> createPrinter;

            if (format == "name")
            {
                createPrinter = (Person person) =>
                {
                    Console.WriteLine($"{person.Name}");
                };
            }
            else if (format == "age")
            {
                createPrinter = (Person person) =>
                {
                    Console.WriteLine($"{person.Age}");
                };
            }
            else
            {
                createPrinter = (Person person) =>
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                };
            }

            return createPrinter;
        }
        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach (var person in people)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
        }
    }
}
