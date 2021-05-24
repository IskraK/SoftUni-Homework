using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> clients = new Queue<string>();

            while (input != "End")
            {
                if (input != "Paid")
                {
                    clients.Enqueue(input);
                }
                else
                {
                    Console.WriteLine(string.Join('\n', clients));
                    clients.Clear();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
