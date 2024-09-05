namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        private double fuel;
        private int horsePower;

        public Vehicle() { }
        public Vehicle(int horsePower, double fuel)
        {
            this.horsePower = horsePower;
            this.fuel = fuel;
        }

        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public virtual void Drive(double kilometers)
        {
            if (this.fuel - FuelConsumption * kilometers >= 0)
            {
                this.fuel -= FuelConsumption * kilometers;
            }
        }
    }
}
