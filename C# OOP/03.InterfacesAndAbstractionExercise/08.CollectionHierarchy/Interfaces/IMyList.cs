using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Interfaces
{
    public interface IMyList:IAddRemoveCollection
    {
        public int Used { get; }
    }
}
