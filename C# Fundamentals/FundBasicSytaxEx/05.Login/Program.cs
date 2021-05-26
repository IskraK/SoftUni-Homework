using System;
using System.Linq;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string reversed = string.Concat(username.Reverse());
            int counter = 0;
            while (true)
            {
                string password = Console.ReadLine();
                counter++;
                if (password == reversed)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    if (counter == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect password. Try again.");
                    }
                }
            }

        }
    }
}

