namespace _02.Vehicles_Extension
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREASE = 1.6;
        private const double REFUELING_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double fuelCapacity)
            : base(fuelQuantity, fuelConsumption, fuelCapacity) { }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }
            protected set { base.FuelConsumption = value + FUEL_CONSUMPTION_INCREASE; }
        }

        public override void Refuel(double fuel)
            => base.Refuel(fuel * REFUELING_MODIFIER);
    }
}
