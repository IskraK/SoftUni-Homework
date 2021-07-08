using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Interfaces
{
    public interface IAddRemoveCollection:IAddCollection
    {
        string Remove();
    }
}
