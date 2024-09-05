using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
		private string name;


		public Animal() { }
		public Animal(string name)
		{
			this.name = name;
		}

		public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

	}
}
