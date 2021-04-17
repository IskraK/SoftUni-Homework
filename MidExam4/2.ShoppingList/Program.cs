using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] commandLine = input.Split();
                string command = commandLine[0];
                string item = commandLine[1];

                switch (command)
                {
                    case "Urgent":
                        if (!shoppingList.Contains(item))
                        {
                            shoppingList.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (shoppingList.Contains(item))
                        {
                            shoppingList.Remove(item);
                        }
                        break;
                    case "Rearrange":
                        if (shoppingList.Contains(item))
                        {
                            shoppingList.Add(item);
                            shoppingList.Remove(item);
                        }
                        break;
                    case "Correct":
                        if (shoppingList.Contains(item))
                        {
                            int idx = shoppingList.IndexOf(item);
                            shoppingList.RemoveAt(idx);
                            shoppingList.Insert(idx, commandLine[2]);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",shoppingList));
        }
    }
}
