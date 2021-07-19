using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Races
        {
            get => this.races.AsReadOnly();
        }

        public void Add(IRace model)
        {
            if (races.Any(r => r.Name == model.Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, model.Name));
            }

            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races;
        }

        public IRace GetByName(string name)
        {
            IRace race = races.FirstOrDefault(r => r.Name == name);
            return race;
        }

        public bool Remove(IRace model)
        {
            if (model == null)
            {
                return false;
            }

            races.Remove(model);
            return true;
        }
    }
}
