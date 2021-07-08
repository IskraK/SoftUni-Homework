using _08.CollectionHierarchy2var.Iterfaces;

namespace _08.CollectionHierarchy2var.Models
{
    public class MyList : Collection, IMyList
    {
        public int Used => this.MyCollection.Count;

        public string Remove()
        {
            string elementToRemove = this.MyCollection[0];
            this.MyCollection.RemoveAt(0);
            return elementToRemove;
        }
    }
}
