using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Vehicle_Catalogue
{
    class Car
    {
        public Car() { }
        public Car(string model, string color, int horsepower)
        {
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Truck
    {
        public Truck() { }
        public Truck(string model, string color, int horsepower)
        {
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "car":

                        cars.Add(new Car(
                            tokens[1],
                            tokens[2],
                            int.Parse(tokens[3])));

                        break;

                    case "truck":

                        trucks.Add(new Truck(
                            tokens[1],
                            tokens[2],
                            int.Parse(tokens[3])));

                        break;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Close the Catalogue")
                {
                    break;
                }

                foreach (var car in cars)
                {
                    if (input == car.Model)
                    {
                        Console.WriteLine($"Type: Car\n" +
                            $"Model: {car.Model}\n" +
                            $"Color: {car.Color}\n" +
                            $"Horsepower: {car.Horsepower}");
                    }
                }

                foreach (var truck in trucks)
                {
                    if (input == truck.Model)
                    {
                        Console.WriteLine($"Type: Truck\n" +
                            $"Model: {truck.Model}\n" +
                            $"Color: {truck.Color}\n" +
                            $"Horsepower: {truck.Horsepower}");
                    }
                }
            }

            double averageCarHP = 0;

            foreach (var car in cars)
            {
                averageCarHP += car.Horsepower;
            }

            averageCarHP /= cars.Count;

            double averageTruckHP = 0;

            foreach (var truck in trucks)
            {
                averageTruckHP += truck.Horsepower;
            }

            averageTruckHP /= trucks.Count;

            Console.WriteLine($"Cars have average horsepower of: {averageCarHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHP:f2}.");
        }
    }
}
