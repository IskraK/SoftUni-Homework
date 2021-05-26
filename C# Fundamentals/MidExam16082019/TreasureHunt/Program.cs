using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chests = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                string[] line = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];

                switch (command)
                {
                    case "Loot":
                        for (int i = 1; i < line.Length; i++)
                        {
                            if (!chests.Contains(line[i]))
                            {
                                chests.Insert(0, line[i]);
                            }
                        }
                        break;
                    case "Drop":
                        int idx = int.Parse(line[1]);
                        if (idx >= 0 && idx < chests.Count)
                        {
                            chests.Add(chests[idx]);
                            chests.RemoveAt(idx);
                        }
                        break;
                    case "Steal":
                        int count = int.Parse(line[1]);
                        List<string> removed = chests.TakeLast(count).ToList();

                        if (count < chests.Count)
                        {
                        chests.RemoveRange(chests.Count - count, count);
                        }
                        else
                        {
                            chests.RemoveRange(0,chests.Count);
                        }

                        Console.WriteLine(string.Join(", ", removed));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }


            if (chests.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double averageGain = 0;
                double sumGain = 0;
                for (int i = 0; i < chests.Count; i++)
                {
                    sumGain += chests[i].Length;
                }
                averageGain = sumGain / chests.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
        }
    }
}
