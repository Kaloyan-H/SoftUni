namespace Formula1.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }
        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }
        public IFormulaOneCar FindByName(string name)
        {
                return models.FirstOrDefault(c => c.Model == name);
        }
    }
}
