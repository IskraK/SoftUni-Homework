namespace _08.CollectionHierarchy2var.Models
{
    public class AddCollection : Collection
    {
        public override int Add(string element)
        {
            base.Add(element);
            int index = this.MyCollection.Count - 1;
            return index;
        }
    }
}
