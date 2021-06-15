using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomLinkedList myList = new CustomLinkedList(new int[] { 5, 7, 12 });

            myList.Foreach(Console.WriteLine);

            myList.AddFirst(100);
            myList.Foreach(Console.WriteLine);

            myList.AddLast(2);
            myList.Foreach(Console.WriteLine);

            Console.WriteLine(myList.RemoveLast());

            Console.WriteLine($"Removed item: {myList.RemoveFirst()}");

            int[] arr = myList.ToArray();
            myList.Foreach(Console.WriteLine);
        }
    }
}
