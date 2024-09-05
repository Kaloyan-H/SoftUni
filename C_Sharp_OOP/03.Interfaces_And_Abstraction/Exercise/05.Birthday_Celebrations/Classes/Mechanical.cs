namespace _05.Birthday_Celebrations.Classes
{
    using Interfaces;

    public abstract class Mechanical : IIdentifiable
    {
        private string model;
        private string id;

        public Mechanical(string model, string id)
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
            get { return id; }
            set { id = value; }
        }
    }
}
