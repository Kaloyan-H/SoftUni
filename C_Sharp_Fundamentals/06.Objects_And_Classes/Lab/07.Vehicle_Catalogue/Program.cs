using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Vehicle_Catalogue
{
    class Program
    {
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }

            public Car() { }

            public Car(string brand, string model, int horsePower)
            {
                this.Brand = brand;
                this.Model = model;
                this.HorsePower = horsePower;
            }
        }
        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }

            public Truck() { }

            public Truck(string brand, string model, int weight)
            {
                this.Brand = brand;
                this.Model = model;
                this.Weight = weight;
            }
        }

        class Catalog
        {
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }

            public Catalog()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }
        }

        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input
                    .Split('/', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Car":

                        catalog.Cars.Add(new Car(tokens[1], tokens[2], int.Parse(tokens[3])));

                        break;

                    case "Truck":

                        catalog.Trucks.Add(new Truck(tokens[1], tokens[2], int.Parse(tokens[3])));

                        break;
                }
            }

            catalog.Cars = catalog.Cars.OrderBy(car => car.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(truck => truck.Brand).ToList();

            if (catalog.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
            }

            foreach (Car car in catalog.Cars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            if (catalog.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
            }

            foreach (Truck truck in catalog.Trucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
