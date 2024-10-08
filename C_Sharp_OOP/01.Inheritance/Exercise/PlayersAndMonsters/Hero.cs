﻿namespace PlayersAndMonsters
{
    public class Hero
    {
		private string username;
		private int level;

		public Hero() { }
		public Hero(string username, int level)
		{
			this.username = username;
			this.level = level;
		}

		public string Username
		{
			get { return username; }
			set { username = value; }
		}
		public int Level
		{
			get { return level; }
			set { level = value; }
		}

		public override string ToString()
		{
			return $"Type: {this.GetType().Name} Username: {this.username} Level: {this.level}";
		}
	}
}
