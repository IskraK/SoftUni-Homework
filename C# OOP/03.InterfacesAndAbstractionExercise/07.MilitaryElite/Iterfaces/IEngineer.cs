using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Iterfaces
{
    public interface IEngineer:ISpecialisedSoldier
    {
        public ICollection<IRepair> Repairs { get;}
    }
}
