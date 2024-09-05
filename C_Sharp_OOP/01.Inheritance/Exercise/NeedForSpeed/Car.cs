namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 3.00;

        public Car() : base() { }
        public Car(int horsePower, double fuel) : base(horsePower, fuel) { }

        public override double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
    }
}
