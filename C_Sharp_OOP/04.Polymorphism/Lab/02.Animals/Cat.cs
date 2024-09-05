using System;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favoritefood)
            : base(name, favoritefood) { }

        public override string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavouriteFood}" +
                $"{Environment.NewLine}MEEOW";
        }
    }
}
