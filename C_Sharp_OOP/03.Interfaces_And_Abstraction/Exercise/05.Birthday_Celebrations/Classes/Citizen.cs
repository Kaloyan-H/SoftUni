using _05.Birthday_Celebrations.Interfaces;
using System.Net.Cache;

namespace _05.Birthday_Celebrations.Classes
{
    public class Citizen : Biological, IIdentifiable
    {
		private int age;
        private string id;

        public Citizen(string name, int age, string id, string birthdate) 
            : base(name, birthdate)
        {
            Age = age;
            Id = id;
        }

        public int Age
		{
			get { return age; }
			set { age = value; }
		}
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
