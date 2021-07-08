using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Iterfaces
{
    interface ICommando:ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get;}
    }
}
