
namespace _06.Food_Shortage.Classes
{
    using Interfaces;

    public class Rebel : Person, IGroupMember
    {
        private string group;

        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            Group = group;
        }

        public string Group
        {
            get { return group; }
            private set { group = value; }
        }

        public override void BuyFood() => Food += 5;
    }
}
