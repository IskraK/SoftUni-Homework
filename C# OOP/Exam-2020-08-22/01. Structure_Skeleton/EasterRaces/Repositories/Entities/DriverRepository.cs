using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using System;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();       
        }

        public IReadOnlyCollection<IDriver> Drivers
        {
            get => this.drivers.AsReadOnly();
        }
        public void Add(IDriver model)
        {
            if (drivers.Any(d => d.Name == model.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, model.Name));
            }

            drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return (IReadOnlyCollection<IDriver>)Drivers;
        }

        public IDriver GetByName(string name)
        {
            IDriver driver = drivers.FirstOrDefault(d => d.Name == name);
            return driver;
        }

        public bool Remove(IDriver model)
        {
            if (model == null)
            {
                return false;
            }

            drivers.Remove(model);
            return true;
        }
    }
}
