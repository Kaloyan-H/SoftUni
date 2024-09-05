
namespace _06.Food_Shortage.Classes
{
    using Interfaces;
    using System.Reflection.Metadata.Ecma335;

    public class Robot : IHasModel, IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Id
        {
            get { return id;}
            set { id = value; }
        }
    }
}
