using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> myList = new DoublyLinkedList<int>(new int[] { 5, 7, 12 });

            myList.ForEach(Console.WriteLine);

            myList.AddFirst(100);
            myList.ForEach(Console.WriteLine);

            myList.AddLast(2);
            myList.ForEach(Console.WriteLine);

            Console.WriteLine($"Removed item: {myList.RemoveLast()}");

            Console.WriteLine($"Removed item: {myList.RemoveFirst()}");

            int[] arr = myList.ToArray();
            myList.ForEach(Console.WriteLine);

            Console.WriteLine("----------------------------------------------------");

            DoublyLinkedList<string> myListStr = new DoublyLinkedList<string>(new string[] { "5", "7", "12" });

            myListStr.AddFirst("Pesho");
            myListStr.AddLast("Gosho");

            myListStr.AddFirst("100");
            myListStr.AddLast("2");

            Console.WriteLine($"Removed item: {myListStr.RemoveLast()}");

            Console.WriteLine($"Removed item: {myListStr.RemoveFirst()}");

            string[] arrStr = myListStr.ToArray();
            myListStr.ForEach(Console.WriteLine);
        }
    }
}
