using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
		private string name;
		private int numberOfBadges = 0;
		private List<Pokemon> pokemons = new List<Pokemon>();

		public Trainer() { }
		public Trainer(string name, Pokemon pokemon)
		{
			this.Name = name;
			this.Pokemons.Add(pokemon);
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int NumberOfBadges
		{
			get { return numberOfBadges; }
			set { numberOfBadges = value; }
		}
		public List<Pokemon> Pokemons
		{
			get { return pokemons; }
			set { pokemons = value; }
		}
	}
}
