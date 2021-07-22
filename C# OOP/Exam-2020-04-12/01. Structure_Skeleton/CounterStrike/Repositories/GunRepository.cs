using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            guns = new List<IGun>();      
        }
        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun gun)
        {
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            guns.Add(gun);
        }

        public IGun FindByName(string name)
        {
            IGun gun = guns.FirstOrDefault(p => p.Name == name);

            return gun;
        }

        public bool Remove(IGun gun)
        {
            return guns.Remove(gun);
        }
    }
}
