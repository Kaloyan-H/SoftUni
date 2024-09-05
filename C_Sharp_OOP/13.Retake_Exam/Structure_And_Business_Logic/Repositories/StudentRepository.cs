namespace UniversityCompetition.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Repositories.Contracts;
    using Models.Contracts;

    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => models.AsReadOnly();

        public void AddModel(IStudent model)
        {
            this.models.Add(model);
        }
        public IStudent FindById(int id)
            => this.models.FirstOrDefault(s => s.Id == id);
        public IStudent FindByName(string name)
        {
            string[] args = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = args[0];
            string lastName = args[1];

            return this.models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
