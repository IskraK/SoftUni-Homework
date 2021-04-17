using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> results = new Dictionary<string, User>(); // <usernames, User>
            Dictionary<string, List<User>> contests = new Dictionary<string, List<User>>();
            string command = Console.ReadLine();
            while (command != "no more time")
            {
                string name = command.Split(" -> ")[0];
                string contest = command.Split(" -> ")[1];
                int points = int.Parse(command.Split(" -> ")[2]);
                User user = new User(name, contest, points);
                bool userExist = false;
                if (results.ContainsKey(name))
                {
                    if (results[name].Contests.ContainsKey(contest)) //contest already exists
                    {
                        userExist = true;
                        if (points > results[name].Contests[contest])
                        {
                            results[name].Contests[contest] = points;
                        }
                    }
                    else
                    {
                        results[name].Contests.Add(contest, points);
                    }
                }
                else
                {
                    results.Add(name, user);
                }

                if (contests.ContainsKey(contest))
                {
                    if (userExist == false)
                    {
                        contests[contest].Add(user);
                    }
                }
                else
                {
                    contests.Add(contest, new List<User>() { user });
                }

                command = Console.ReadLine();
            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int position = 1;
                foreach (var item in contest.Value.OrderByDescending(p => p.Contests[contest.Key]).ThenBy(n => n.Username))
                {
                    Console.WriteLine($"{position}. {item.Username} <::> {item.Contests[contest.Key]}");
                    position++;
                }
            }

            Console.WriteLine("Individual standings:");
            int overalPosition = 1;
            foreach (var item in results.OrderByDescending(p => p.Value.Contests.Values.Sum()).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{overalPosition}. {item.Key} -> {item.Value.Contests.Values.Sum()}");
                overalPosition++;
            }
        }
    }

    public class User
    {
        public string Username { get; set; }
        public Dictionary<string, int> Contests { get; set; } // <contests, points>
        public User(string username, string contest, int points)
        {
            Username = username;
            Contests = new Dictionary<string, int>() { { contest, points } };
        }
    }
}
