using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> firstLoot = new Queue<int>(firstInput);
            Stack<int> secondLoot = new Stack<int>(secondInput);

            int claimedItems = 0;

            while (firstLoot.Count > 0 && secondLoot.Count > 0)
            {
                int sum = firstLoot.Peek() + secondLoot.Peek();
                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstLoot.Dequeue();
                    secondLoot.Pop();
                }
                else
                {
                    firstLoot.Enqueue(secondLoot.Pop());
                }
            }

            if (firstLoot.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLoot.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
