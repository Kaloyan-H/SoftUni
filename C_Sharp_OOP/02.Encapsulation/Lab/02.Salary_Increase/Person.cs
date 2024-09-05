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
            get { return firstName; }
            private set { firstName = value; }
        }
        public string LastName
		{
			get { return lastName; }
			private set { lastName = value; }
		}
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }
        public decimal Salary
        {
            get { return salary; }
            private set { salary = value; }
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
