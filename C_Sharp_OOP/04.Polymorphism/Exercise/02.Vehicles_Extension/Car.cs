namespace _02.Vehicles_Extension
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREASE = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double fuelCapacity)
            : base(fuelQuantity, fuelConsumption, fuelCapacity) { }

        public override double FuelConsumption
        { 
            get { return base.FuelConsumption; }
            protected set { base.FuelConsumption = value + FUEL_CONSUMPTION_INCREASE; }
        }
    }
}
