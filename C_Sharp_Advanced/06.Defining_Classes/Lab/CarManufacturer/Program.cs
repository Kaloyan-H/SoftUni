using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }

                string[] cmdArgs = input
                    .Split();

                var tirePack = new Tire[4];
                int j = 0;
                for (int i = 0; i < tirePack.Length; i++, j += 2)
                {
                    tirePack[i] = new Tire(int.Parse(cmdArgs[j]), double.Parse(cmdArgs[j + 1]));
                }

                tires.Add(tirePack);
            }

            List<Engine> engines = new List<Engine>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                string[] cmdArgs = input
                    .Split();

                engines.Add(new Engine(int.Parse(cmdArgs[0]), double.Parse(cmdArgs[1])));
            }

            List<Car> cars = new List<Car>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                string[] cmdArgs = input
                    .Split();

                string make = cmdArgs[0];
                string model = cmdArgs[1];
                int year = int.Parse(cmdArgs[2]);
                double fuelQuantity = double.Parse(cmdArgs[3]);
                double fuelConsumption = double.Parse(cmdArgs[4]);
                int engineIndex = int.Parse(cmdArgs[5]);
                int tiresIndex = int.Parse(cmdArgs[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption / 100, engines[engineIndex], tires[tiresIndex]));
            }

            cars = cars
                .Where(x => x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.TirePressure() > 9
                && x.TirePressure() < 10)
                .Select((x) =>
                {
                    x.Drive(20);
                    return x;
                })
                .ToList();



            foreach (var car in cars)
            {
                Console.WriteLine($"Make: {car.Make}\n" +
                    $"Model: {car.Model}\n" +
                    $"Year: {car.Year}\n" +
                    $"HorsePowers: {car.Engine.HorsePower}\n" +
                    $"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}