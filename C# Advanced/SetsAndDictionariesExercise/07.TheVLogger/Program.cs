using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> vlogerFollowers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> vlogerFollowings = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] parts = input.Split();
                string vlogerName = parts[0];
                string command = parts[1];

                if (command == "joined")
                {
                    if (!vlogerFollowers.ContainsKey(vlogerName))
                    {
                    vlogerFollowers[vlogerName] = new HashSet<string>();
                    vlogerFollowings[vlogerName] = new HashSet<string>();
                    }
                }
                else if (command == "followed")
                {
                    string followedVlogger = parts[2];

                    if (vlogerName != followedVlogger)
                    {
                        if (vlogerFollowers.ContainsKey(followedVlogger) && vlogerFollowings.ContainsKey(vlogerName))
                        {
                            vlogerFollowers[followedVlogger].Add(vlogerName);
                            vlogerFollowings[vlogerName].Add(followedVlogger);
                        } 
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogerFollowers.Count} vloggers in its logs.");

            var orderVlogerFollowers = vlogerFollowers.OrderByDescending(n => n.Value.Count)
                .ThenBy(n => vlogerFollowings[n.Key].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            int count = 1;

            //KeyValuePair<string,HashSet<string>> bestVloger = orderVlogerFollowers.First();
            //string bestVlogerName = bestVloger.Key;
            //HashSet<string> bestVlogerFollowers = bestVloger.Value.OrderBy(n => n).ToHashSet();

            //Console.WriteLine($"{count++}. {bestVlogerName} : {bestVlogerFollowers.Count} followers, {vlogerFollowings[bestVlogerName].Count} following");

            //foreach (var follower in bestVlogerFollowers)
            //{
            //    Console.WriteLine($"*  {follower}");
            //}

            //foreach (var vloger in orderVlogerFollowers.Skip(1))
            //{
            //    Console.WriteLine($"{count++}. {vloger.Key} : {orderVlogerFollowers[vloger.Key].Count} followers, {vlogerFollowings[vloger.Key].Count} following");
            //}

            foreach (var vloger in orderVlogerFollowers)
            {
                Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value.Count} followers, {vlogerFollowings[vloger.Key].Count} following");

                if (count == 1)
                {
                    foreach (var follower in vloger.Value.OrderBy(n => n))
                    {
                        Console.WriteLine($"*  {follower}");

                    }
                }

                count++;
            }
        }
    }
}
