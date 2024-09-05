namespace Formula1.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IPilot model)
        {
            this.models.Add(model);
        }
        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }
        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(c => c.FullName == name);
        }
    }
}
