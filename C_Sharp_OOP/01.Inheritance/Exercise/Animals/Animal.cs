using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public virtual string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public virtual string ProduceSound() => string.Empty;
        public override string ToString() => $"{this.GetType().Name}{Environment.NewLine}" +
            $"{this.Name} {this.Age} {this.Gender}";
    }
}
