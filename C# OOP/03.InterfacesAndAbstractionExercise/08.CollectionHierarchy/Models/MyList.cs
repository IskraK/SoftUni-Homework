using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    using Interfaces;
    public class MyList : IMyList
    {
        public int Used => Collection.Count;

        public List<string> Collection { get; private set; }

        public MyList()
        {
            Collection = new List<string>();       
        }

        public int Add(string element)
        {
            int index = 0;
            Collection.Insert(index, element);
            return index;
        }

        public string Remove()
        {
            string removedElement = Collection[0];
            Collection.RemoveAt(0);
            return removedElement;
        }
    }
}
