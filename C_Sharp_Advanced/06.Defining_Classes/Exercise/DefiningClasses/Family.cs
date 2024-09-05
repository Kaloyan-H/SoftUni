using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people =  new List<Person>();

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }
        public Person GetOldestMember()
        {
            int greatestAge = int.MinValue;
            var oldestPerson = new Person();

            foreach (var person in people)
            {
                if (person.Age > greatestAge)
                {
                    greatestAge = person.Age;
                    oldestPerson = person;
                }
            }

            return oldestPerson;
        }
    }
}
