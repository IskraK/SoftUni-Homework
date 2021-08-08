using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;
        public EggRepository()
        {
            models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => this.models.AsReadOnly();

        public void Add(IEgg model)
        {
            if (models.All(b => b.Name != model.Name))
            {
                models.Add(model);
            }
        }

        public IEgg FindByName(string name)
        {
            return models.FirstOrDefault(b => b.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return models.Remove(model);
        }
    }
}
