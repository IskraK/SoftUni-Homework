using System;
using System.Collections.Generic;
using System.Text;
using _08.CollectionHierarchy2var.Iterfaces;

namespace _08.CollectionHierarchy2var.Models
{
    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public string Remove()
        {
            string elementToRemove = MyCollection[MyCollection.Count - 1];
            MyCollection.RemoveAt(MyCollection.Count - 1);
            return elementToRemove;
        }
    }
}
