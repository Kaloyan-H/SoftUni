namespace _06.Food_Shortage.Classes
{
    using Interfaces;

    public class Pet : INamed, IBirthed
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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
    }
}
