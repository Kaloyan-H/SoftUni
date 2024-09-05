namespace _03.Raiding
{
    public abstract class BaseHero
    {
		private string name;
		private int power;

		public BaseHero(string name, int power)
		{
			Name = name;
			Power = power;
		}

		public virtual string Name
		{
			get { return name; }
			protected set { name = value; }
		}
		public virtual int Power
		{
			get { return power; }
			protected set { power = value; }
		}

		public abstract string CastAbility();
	}
}
