using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
		private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set 
            {
                if (value.Length >= 3) this.firstName = value;
                else throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
        }
        public string LastName
		{
			get { return this.lastName; }
			private set 
            {
                if (value.Length >= 3) this.lastName = value;
                else throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
		}
        public int Age
        {
            get { return this.age; }
            private set 
            {
                if (value > 0) this.age = value;
                else throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
        }
        public decimal Salary
        {
            get { return this.salary; }
            private set 
            {
                if (value >= 650) this.salary = value;
                else throw new ArgumentException("Salary cannot be less than 650 leva!");
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.age < 30)
            {
                salary += salary * (percentage / 200);
                return;
            }
            salary += salary * (percentage / 100);
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
