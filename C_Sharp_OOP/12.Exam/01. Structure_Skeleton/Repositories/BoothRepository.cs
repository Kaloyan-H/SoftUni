namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using Models.Booths.Contracts;
    using Contracts;

    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> models;

        public BoothRepository()
        {
            this.models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void AddModel(IBooth model)
        {
            this.models.Add(model);
        }
    }
}
