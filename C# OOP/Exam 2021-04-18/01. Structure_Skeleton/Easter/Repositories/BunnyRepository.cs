using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;
        public BunnyRepository()
        {
            models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => this.models.AsReadOnly();

        public void Add(IBunny model)
        {
            if (models.All(b => b.Name != model.Name))
            {
                models.Add(model);
            }
        }

        public IBunny FindByName(string name)
        {
            return models.FirstOrDefault(b => b.Name == name);
        }

        public bool Remove(IBunny model)
        {
            return models.Remove(model);
        }
    }
}
