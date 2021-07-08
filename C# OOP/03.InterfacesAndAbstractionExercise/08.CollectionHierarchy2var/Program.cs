using System;
using System.Collections.Generic;
using _08.CollectionHierarchy2var.Iterfaces;
using _08.CollectionHierarchy2var.Models;

namespace _08.CollectionHierarchy2var
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            int countElementsToRemove = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> resultAddCollection = new List<int>();
            List<int> resultAddRemoveCollection = new List<int>();
            List<int> resultMyList = new List<int>();
            List<string> resultRemovedAddRemoveCollection = new List<string>();
            List<string> resultRenovedMyList = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                resultAddCollection.Add(addCollection.Add(input[i]));
                resultAddRemoveCollection.Add(addRemoveCollection.Add(input[i]));
                resultMyList.Add(myList.Add(input[i]));
            }

            for (int i = 0; i < countElementsToRemove; i++)
            {
                resultRemovedAddRemoveCollection.Add(addRemoveCollection.Remove());
                resultRenovedMyList.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', resultAddCollection));
            Console.WriteLine(string.Join(' ', resultAddRemoveCollection));
            Console.WriteLine(string.Join(' ', resultMyList));
            Console.WriteLine(string.Join(' ', resultRemovedAddRemoveCollection));
            Console.WriteLine(string.Join(' ', resultRenovedMyList));
        }
    }
}
