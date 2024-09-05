namespace UniversityCompetition.Repositories
{
    using Models;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using UniversityCompetition.Models.Contracts;

    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> models;

        public SubjectRepository()
        {
            models = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => models.AsReadOnly();

        public void AddModel(ISubject model)
        {
            this.models.Add(model);
        }
        public ISubject FindById(int id)
            => this.models.FirstOrDefault(s => s.Id == id);
        public ISubject FindByName(string name)
            => this.models.FirstOrDefault(s => s.Name == name);
    }
}
