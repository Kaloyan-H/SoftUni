namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 8.00;

        public RaceMotorcycle() : base() { }
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel) { }

        public override double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
    }
}
