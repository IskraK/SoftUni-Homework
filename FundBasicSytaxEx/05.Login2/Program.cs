using System;

namespace _05.Login2
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string reversed = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                reversed += username[i];
            }
            int counter = 0;
            while (true)
            {
                string password = Console.ReadLine();
                counter++;
                if (counter <= 4)
                {
                    if (password == reversed)
                    {
                        Console.WriteLine($"User {username} logged in.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect password. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
            }
        }
    }
}