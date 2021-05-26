using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string item = commands[1];

                switch (command)
                {
                    case "Collect":
                        if (!inventory.Contains(item))
                        {
                            inventory.Add(item);
                        }
                        break;
                    case "Drop":
                        if (inventory.Contains(item))
                        {
                            inventory.Remove(item);
                        }
                        break;
                    case "Combine Items":
                        string[] items=item.Split(":").ToArray();
                        string oldItem = items[0];
                        string newItem = items[1];

                        if (inventory.Contains(oldItem))
                        {
                            int idx = inventory.IndexOf(oldItem);
                            inventory.Insert(idx + 1, newItem);
                        }
                        break;
                    case "Renew":
                        if (inventory.Contains(item))
                        {
                            inventory.Add(item);
                            inventory.Remove(item);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",inventory));
        }
    }
}
