namespace _06.Food_Shortage.Classes
{
    using Interfaces;

    public abstract class Person : INamed, IAging, IBuyer
    {
        private string name;
        private int age;
        private int food;

        private Person()
        {
            Food = 0;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public int Age
        {
            get { return age; }
            protected set { age = value; }
        }
        public int Food
        {
            get { return food; }
            protected set { food = value; }
        }

        public abstract void BuyFood();
    }
}
