using System;
using System.Collections.Generic;

namespace _5.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string username = input[1];

                switch (command)
                {
                    case "register":
                        string licenseNumber = input[2];
                        if (users.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licenseNumber}");
                        }
                        else
                        {
                            users.Add(username, licenseNumber);
                            Console.WriteLine($"{username} registered {licenseNumber} successfully");
                        }
                        break;
                    case "unregister":
                        if (users.ContainsKey(username))
                        {
                            users.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
