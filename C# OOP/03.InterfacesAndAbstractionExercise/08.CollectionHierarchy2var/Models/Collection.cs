using System.Collections.Generic;

using _08.CollectionHierarchy2var.Iterfaces;

namespace _08.CollectionHierarchy2var.Models
{
    public abstract class Collection : IAddCollection
    {
       public Collection()
        {
            MyCollection = new List<string>();
        }
        protected List<string> MyCollection { get; }

        public virtual int Add(string element)
        {
            int index = 0;
            MyCollection.Insert(index, element);
            return index;
        }
    }
}
