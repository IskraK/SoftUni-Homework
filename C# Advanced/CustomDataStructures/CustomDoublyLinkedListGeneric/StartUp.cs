using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomLinkedList<int> myList = new CustomLinkedList<int>(new int[] { 5, 7, 12 });

            myList.Foreach(Console.WriteLine);

            myList.AddFirst(100);
            myList.Foreach(Console.WriteLine);

            myList.AddLast(2);
            myList.Foreach(Console.WriteLine);

            Console.WriteLine($"Removed item: {myList.RemoveLast()}");

            Console.WriteLine($"Removed item: {myList.RemoveFirst()}");

            int[] arr = myList.ToArray();
            myList.Foreach(Console.WriteLine);

            Console.WriteLine("----------------------------------------------------");

            CustomLinkedList<string> myListStr = new CustomLinkedList<string>(new string[] { "5", "7", "12" });

            myListStr.AddFirst("Pesho");
            myListStr.AddLast("Gosho");

            myListStr.AddFirst("100");
            myListStr.AddLast("2");

            Console.WriteLine($"Removed item: {myListStr.RemoveLast()}");

            Console.WriteLine($"Removed item: {myListStr.RemoveFirst()}");

            string[] arrStr = myListStr.ToArray();
            myListStr.Foreach(Console.WriteLine);
        }
    }
}
