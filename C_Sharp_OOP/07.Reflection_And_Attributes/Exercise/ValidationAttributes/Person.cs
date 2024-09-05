namespace ValidationAttributes
{
    public class Person
    {
		private const int MIN_AGE = 12;
		private const int MAX_AGE = 90;
		private string fullName;
		private int age;

		public Person(string fullName, int age)
		{
			FullName = fullName;
			Age = age;
		}

		[MyRequired]
		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
		[MyRange(MIN_AGE, MAX_AGE)]
		public int Age
		{
			get { return age; }
			set { age = value; }
		}

	}
}
