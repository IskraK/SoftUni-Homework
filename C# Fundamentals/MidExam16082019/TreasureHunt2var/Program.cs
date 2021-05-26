using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt2var
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "Yohoho!")
            {
                if (command[0] == "Loot")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        if (!treasureChest.Contains(command[i]))
                        {
                            treasureChest.Insert(0, command[i]);
                        }
                    }
                }
                if (command[0] == "Drop" && 0 <= int.Parse(command[1]) && int.Parse(command[1]) < treasureChest.Count)
                {
                    treasureChest.Add(treasureChest[int.Parse(command[1])]);
                    treasureChest.RemoveAt(int.Parse(command[1]));
                }
                if (command[0] == "Steal")
                {
                    if (treasureChest.Count <= int.Parse(command[1]))
                    {
                        Console.WriteLine(string.Join(", ", treasureChest));
                        treasureChest.RemoveRange(0, treasureChest.Count);
                    }
                    else
                    {
                        List<string> removed = new List<string>();
                        for (int i = treasureChest.Count - int.Parse(command[1]); i < treasureChest.Count; i++)
                        {
                            removed.Add(treasureChest[i]);
                            treasureChest.RemoveAt(i);
                            i--;
                        }
                        Console.WriteLine(string.Join(", ", removed));
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            if (treasureChest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double totalLength = 0;
                foreach (string item in treasureChest)
                {
                    totalLength += item.Length;
                }
                Console.WriteLine($"Average treasure gain: {totalLength / treasureChest.Count:f2} pirate credits.");
            }
        }
    }
}
