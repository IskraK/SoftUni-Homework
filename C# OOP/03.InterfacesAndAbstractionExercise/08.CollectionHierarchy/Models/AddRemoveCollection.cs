using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    using Interfaces;
    using System.Linq;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        public List<string> Collection { get; private set; }

        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string element)
        {
            Collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string removedElement = Collection.ElementAtOrDefault(Collection.Count - 1);
            Collection.RemoveAt(Collection.Count - 1);
            return removedElement;
        }
    }
}
