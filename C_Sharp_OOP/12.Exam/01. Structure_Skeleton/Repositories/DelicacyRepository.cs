namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using Models.Delicacies.Contracts;
    using Contracts;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models;

        public DelicacyRepository()
        {
            this.models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(IDelicacy model)
        {
            this.models.Add(model);
        }
    }
}
