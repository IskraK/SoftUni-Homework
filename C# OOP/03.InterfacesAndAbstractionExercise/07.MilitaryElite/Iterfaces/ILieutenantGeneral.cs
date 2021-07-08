using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Iterfaces
{
    public interface ILieutenantGeneral:IPrivate
    {
        public ICollection<IPrivate> Privates { get; }
    }
}
