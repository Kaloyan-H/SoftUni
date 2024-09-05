using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine()
                .Split(new string[] { " ;", "; ", " ; ", ";" }, StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            foreach (var personInput in peopleInput)
            {
                string[] personArgs = personInput.Split("=");
                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);
                try
                {
                    people.Add(new Person(name, money));
                }
                catch (ArgumentException f)
                {
                    Console.WriteLine(f.Message);
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (input == "END")
                        {
                            return;
                        }
                    }
                }
            }

            string[] productsInput = Console.ReadLine()
                .Split(new string[] { " ;", "; ", " ; ", ";" }, StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            foreach (var productInput in productsInput)
            {
                string[] productArgs = productInput.Split("=");
                string name = productArgs[0];
                decimal price = decimal.Parse(productArgs[1]);
                try
                {
                    products.Add(new Product(name, price));
                }
                catch (ArgumentException t)
                {
                    Console.WriteLine(t.Message);
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (input == "END")
                        {
                            return;
                        }
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    foreach (var person in people)
                    {
                        Console.WriteLine(person);
                    }
                    return;
                }

                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person testSubject = people.Find(p => p.Name == command[0]);
                Product testProduct = products.Find(p => p.Name == command[1]);
                if (testSubject != null && testProduct != null)
                {
                    testSubject.Buy(testProduct);
                }
            }
        }
    }
}
