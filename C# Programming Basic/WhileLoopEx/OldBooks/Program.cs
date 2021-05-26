using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            int count = 0;
            string currBook = Console.ReadLine();
            while (currBook != "No More Books")
            {
                if (currBook == wantedBook)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }
                else
                {
                    count++;
                    currBook = Console.ReadLine();
                }
            }
            if (currBook != wantedBook)
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}
