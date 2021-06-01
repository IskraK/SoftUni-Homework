using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger3var
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vlogers = new Dictionary<string, List<string>>();
            Dictionary<string, int[]> vlogerNumberOfFollowers = new Dictionary<string, int[]>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vlogerName = parts[0];
                string command = parts[1];

                if (command == "joined")
                {
                    if (!vlogers.ContainsKey(vlogerName))
                    {
                        vlogers.Add(vlogerName, new List<string>());
                        vlogerNumberOfFollowers.Add(vlogerName, new int[2]);
                    }
                }
                else if (command == "followed")
                {
                    string followedVloger = parts[2];

                    if (vlogers.ContainsKey(vlogerName) && vlogers.ContainsKey(followedVloger))
                    {
                        if (!vlogers[followedVloger].Contains(vlogerName) && vlogerName != followedVloger)
                        {
                            vlogers[followedVloger].Add(vlogerName);
                            vlogerNumberOfFollowers[followedVloger][0]++;
                            vlogerNumberOfFollowers[vlogerName][1]++;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            var orderedVlogersAndFollowers = vlogerNumberOfFollowers
                .OrderByDescending(n => n.Value[0])
                .ThenBy(n => n.Value[1])
                .ToDictionary(x => x.Key, y => y.Value);

            int count = 1;
            string bestVloger = string.Empty;

            foreach (var kvp in orderedVlogersAndFollowers)
            {
                bestVloger = kvp.Key;
                Console.WriteLine($"{count}. {bestVloger} : {kvp.Value[0]} followers, {kvp.Value[1]} following");

                count++;

                if (vlogers[bestVloger].Count > 0)
                {
                    foreach (var follower in vlogers[bestVloger].OrderBy(n => n))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                break;
            }

            orderedVlogersAndFollowers.Remove(bestVloger);

            foreach (var kvp in orderedVlogersAndFollowers)
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                count++;
            }
        }
    }
}
