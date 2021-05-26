using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Ranking2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Contest> contestAndPass = new Dictionary<string, Contest>();
            string command = Console.ReadLine();
            while (command != "end of contests")
            {
                string name = command.Split(":")[0];
                string password = command.Split(":")[1];
                if (contestAndPass.ContainsKey(name) == false)
                {
                    Contest contest = new Contest(name, password);
                    contestAndPass.Add(name, contest);
                }

                command = Console.ReadLine();
            }

            SortedDictionary<string, User> usersAndContests = new System.Collections.Generic.SortedDictionary<string, User>();
            string commandTwo = Console.ReadLine();
            while (commandTwo != "end of submissions")
            {
                string nameOfContest = commandTwo.Split("=>")[0];
                string password = commandTwo.Split("=>")[1];
                if (contestAndPass.ContainsKey(nameOfContest) && contestAndPass[nameOfContest].Password == password)
                {
                    string username = commandTwo.Split("=>")[2];
                    int points = int.Parse(commandTwo.Split("=>")[3]);
                    if (usersAndContests.ContainsKey(username))
                    {
                        if (usersAndContests[username].Contests.ContainsKey(nameOfContest))
                        {
                            if (points > usersAndContests[username].Contests[nameOfContest])
                            {
                                usersAndContests[username].Contests[nameOfContest] = points;
                            }
                        }
                        else
                        {
                            usersAndContests[username].Contests.Add(nameOfContest, points);
                        }
                    }
                    else
                    {
                        User user = new User(username, points, nameOfContest);
                        usersAndContests.Add(username, user);
                    }
                }

                commandTwo = Console.ReadLine();
            }

            string bestUser = User.BestUser(usersAndContests);
            Console.WriteLine($"Best candidate is {bestUser} with total {usersAndContests[bestUser].Contests.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in usersAndContests)
            {
                Console.WriteLine(user.Key);
                foreach (var item in user.Value.Contests.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }

    public class User
    {
        public string Username { get; set; }
        public Dictionary<string, int> Contests { get; set; }
        public User(string username, int points, string contest)
        {
            Username = username;
            Contests = new Dictionary<string, int>() { { contest, points } };
        }

        public static string BestUser(SortedDictionary<string, User> usersAndContests)
        {
            int maxPoint = 0;
            string bestUser = "";
            foreach (var user in usersAndContests)
            {
                int currPoint = user.Value.Contests.Values.Sum();
                if (currPoint > maxPoint)
                {
                    maxPoint = currPoint;
                    bestUser = user.Key;
                }
            }

            return bestUser;
        }
    }


    public class Contest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Contest(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
