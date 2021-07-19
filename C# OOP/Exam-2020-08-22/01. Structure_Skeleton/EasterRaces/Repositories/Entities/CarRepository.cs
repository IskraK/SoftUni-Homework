using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Cars
        {
            get => cars.AsReadOnly();
        }

        public void Add(ICar model)
        {
            if (cars.Any(c => c.Model == model.Model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists,model.Model));
            }

            cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return cars;
        }

        public ICar GetByName(string name)
        {
            ICar car = cars.FirstOrDefault(c => c.Model == name);
            return car;
        }

        public bool Remove(ICar model)
        {
            if (model == null)
            {
                return false;
            }

            cars.Remove(model);
            return true;
        }
    }
}
