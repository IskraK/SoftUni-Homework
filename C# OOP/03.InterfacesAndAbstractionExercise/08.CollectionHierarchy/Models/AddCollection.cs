﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    using Interfaces;
    public class AddCollection : IAddCollection
    {
        public List<string> Collection { get; private set; }
        public AddCollection()
        {
            Collection = new List<string>();      
        }
        public int Add(string element)
        {
            Collection.Add(element);
            return Collection.Count - 1;
        }
    }
}
