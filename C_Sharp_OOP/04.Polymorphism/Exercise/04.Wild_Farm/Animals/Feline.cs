namespace _04.Wild_Farm.Animals
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion) 
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            protected set { breed = value; }
        }

        public override string ToString()
            => $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
