namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;
    using Models.Cocktails.Contracts;
    using Contracts;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> models;

        public CocktailRepository()
        {
            this.models = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(ICocktail model)
        {
            this.models.Add(model);
        }
    }
}
