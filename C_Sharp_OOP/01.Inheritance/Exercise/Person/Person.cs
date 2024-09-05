using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person() { }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value >= 0) age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"Name: {this.name}, Age: {this.age}");

            return stringBuilder.ToString();
        }
    }
}
