namespace Formula1.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }
        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(c => c.RaceName == name);
        }
    }
}
