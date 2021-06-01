using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] contestInfo = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = contestInfo[0];
                string password = contestInfo[1];
                contests.Add(contest, password);

                input = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line != "end of submissions")
            {
                //{contest}=>{password}=>{username}=>{points}
                string[] info = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = info[0];
                string password = info[1];
                string user = info[2];
                int points = int.Parse(info[3]);

                if (contests.Any(x => x.Key == contest))
                {
                    if (contests[contest] == password)
                    {
                        if (!users.ContainsKey(user))
                        {
                            users.Add(user, new Dictionary<string, int>());
                        }

                        if (!users[user].ContainsKey(contest))
                        {
                            users[user].Add(contest, points);
                        }
                        else
                        {
                            if (users[user][contest] < points)
                            {
                                users[user][contest] = points;
                            }
                        }
                    }
                }

                line = Console.ReadLine();
            }

            var orderUsers = users.OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"Best candidate is {orderUsers.First().Key} with total {orderUsers.First().Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
