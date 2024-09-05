using System;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;//In liters
        private double fuelConsumption;//In liters per kilometer

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
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

        public virtual void Drive(double distance)
        {
            if (this.FuelQuantity - this.FuelConsumption * distance >= 0)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else Console.WriteLine($"{this.GetType().Name} needs refueling"); 
        }
        public virtual void Refuel(double fuel)
            => this.FuelQuantity += fuel;
        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
