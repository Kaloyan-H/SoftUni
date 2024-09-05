namespace _06.Food_Shortage.Classes
{
    using Interfaces;

    public class Citizen : Person, IIdentifiable, IBirthed
    {
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate) 
            : base(name, age)
        {
            Id = id;
            Birthdate = birthdate;
        }

        public string Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string Birthdate
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
                string[] birthdateInfo = value.Split("/");
                BirthDay = birthdateInfo[0];
                BirthMonth = birthdateInfo[1];
                BirthYear = birthdateInfo[2];
            }
        }
        public string BirthDay { get; private set; }/*=> Birthdate.Split("/")[0]*/
        public string BirthMonth { get; private set; }/*=> Birthdate.Split("/")[1]*/
        public string BirthYear { get; private set; }/*=> Birthdate.Split("/")[2]*/

        public override void BuyFood() => Food += 10;
    }
}
