namespace NavalVessels.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Contracts;
    using Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models;

        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models
            => this.models.AsReadOnly();

        public void Add(IVessel model)
        {
            models.Add(model);
        }
        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }
        public bool Remove(IVessel model)
        {
            return models.Remove(model);
        }
    }
}
