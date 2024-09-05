using System;

namespace _02.Vehicles_Extension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;//In liters
        private double fuelConsumption;//In liters per kilometer
        private double fuelCapacity;//In liters

        public Vehicle(double fuelQuantity, double fuelConsumption, double fuelCapacity)
        {
            this.FuelCapacity = fuelCapacity;
            if (fuelQuantity > fuelCapacity)
                this.FuelQuantity = 0;
            else
                this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set { fuelQuantity = value; }
        }
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set { fuelConsumption = value; }
        }
        public virtual double FuelCapacity
        {
            get { return fuelCapacity; }
            protected set { fuelCapacity = value; }
        }

        public virtual void Drive(double distance, bool busModifier)
        {
            if (!busModifier)
                if (this.FuelQuantity - this.FuelConsumption * distance >= 0)
                {
                    this.FuelQuantity -= this.FuelConsumption * distance;
                    Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                }
                else Console.WriteLine($"{this.GetType().Name} needs refueling");
            else
            {
                if (this.FuelQuantity - (this.FuelConsumption + 1.4) * distance >= 0)
                {
                    this.FuelQuantity -= (this.FuelConsumption + 1.4) * distance;
                    Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                }
                else Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel > 0)
            {
                if (this.FuelQuantity + fuel <= this.FuelCapacity)
                    this.FuelQuantity += fuel;
                else if (this.GetType().Name == "Truck") Console.WriteLine($"Cannot fit {fuel / 0.95} fuel in the tank");
                else Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else Console.WriteLine("Fuel must be a positive number");
        }
        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
