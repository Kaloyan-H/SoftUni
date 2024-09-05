namespace _04.Wild_Farm.Animals
{
    using Foods;

    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return livingRegion; }
            protected set { livingRegion = value; }
        }
    }
}
