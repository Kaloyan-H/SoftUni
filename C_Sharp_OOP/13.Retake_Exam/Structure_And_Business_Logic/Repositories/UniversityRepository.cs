namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Contracts;
    using Repositories.Contracts;

    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;

        public UniversityRepository()
        {
            models = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => models.AsReadOnly();

        public void AddModel(IUniversity model)
        {
            this.models.Add(model);
        }
        public IUniversity FindById(int id)
            => this.models.FirstOrDefault(s => s.Id == id);
        public IUniversity FindByName(string name)
            => this.models.FirstOrDefault(s => s.Name == name);
    }
}
