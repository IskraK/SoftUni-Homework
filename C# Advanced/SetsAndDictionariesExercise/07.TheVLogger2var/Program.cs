using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vloger> vlogers = new Dictionary<string, Vloger>();

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
                        Vloger vloger = new Vloger(vlogerName);
                        vlogers.Add(vlogerName, vloger);
                    }
                }
                else
                {
                    string followedVloger = parts[2];

                    if (vlogerName != followedVloger && vlogers.ContainsKey(vlogerName) && vlogers.ContainsKey(followedVloger))
                    {
                        vlogers[vlogerName].Following.Add(followedVloger);
                        vlogers[followedVloger].Followers.Add(vlogerName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");
            int count = 1;
            vlogers = vlogers.OrderByDescending(n => n.Value.Followers.Count)
                .ThenBy(n => n.Value.Following.Count)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in vlogers)
            {
                Console.WriteLine($"{count}. {item.Key} : {item.Value.Followers.Count} followers, {item.Value.Following.Count} following");

                if (count == 1)
                {
                    foreach (var follower in item.Value.Followers.OrderBy(n => n))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }

    internal class Vloger
    {
        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

        public Vloger(string name)
        {
            this.Name = name;
            this.Followers = new HashSet<string>();
            this.Following = new HashSet<string>();
        }
    }
}
