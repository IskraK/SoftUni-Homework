using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Interfaces
{
    public interface IAddCollection
    {
        public List<string> Collection { get;}
        int Add(string element);
    }
}
