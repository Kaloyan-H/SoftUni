namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREASE = 1.6;
        private const double REFUELING_MODIFIER = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption) { }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }
            protected set { base.FuelConsumption = value + FUEL_CONSUMPTION_INCREASE; }
        }

        public override void Refuel(double fuel)
            => base.FuelQuantity += fuel * REFUELING_MODIFIER;
    }
}
