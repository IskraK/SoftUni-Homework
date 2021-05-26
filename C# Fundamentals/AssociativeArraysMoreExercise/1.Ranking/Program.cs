using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordByContest = new Dictionary<string, string>();

            string line = Console.ReadLine();

            while (line != "end of contests")
            {
                string[] parts = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = parts[0];
                string password = parts[1];

                if (!passwordByContest.ContainsKey(contest))
                {
                    passwordByContest.Add(contest, password);
                }

                line = Console.ReadLine();
            }

            //“{ contest}=>{ password}=>{ username}=>{ points}” until you receive “end of submissions”. 

            Dictionary<string, List<string>> contestsByUser = new Dictionary<string, List<string>>();
            Dictionary<string, List<int>> pointsByUser = new Dictionary<string, List<int>>();

            string input = Console.ReadLine();
            Dictionary<string, int> pointsByContest = new Dictionary<string, int>();

            while (input != "end of submissions")
            {
                string[] parts = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = parts[0];
                string password = parts[1];
                string user = parts[2];
                int points = int.Parse(parts[3]);


                if (passwordByContest.ContainsKey(contest) && passwordByContest[contest] == password)
                {
                    if (!contestsByUser.ContainsKey(user))
                    {
                        contestsByUser.Add(user, new List<string>());
                        pointsByUser.Add(user, new List<int>());
                        pointsByContest.Add(contest, 0);
                    }
                    contestsByUser[user].Add(contest);
                    pointsByUser[user].Add(points);

                    if (contestsByUser[user].Contains(contest) && pointsByContest[contest] < points)
                    {
                        pointsByUser[user].Add(points);
                        pointsByContest[contest] = points;
                    }
                    //не работи!!!
                }

                input = Console.ReadLine();
            }

            int maxTotalPoints = 0;
            string bestSudent = string.Empty;
            foreach (var kvp in pointsByUser)
            {
                string user = kvp.Key;
                List<int> poits = kvp.Value;
                int totalPoints = kvp.Value.Sum();
                if (maxTotalPoints < totalPoints)
                {
                    maxTotalPoints = totalPoints;
                    bestSudent = user;
                }
            }

            Console.WriteLine($"Best candidate is {bestSudent} with total {maxTotalPoints} points.");
            Console.WriteLine("Ranking:");

            //print all students ordered by their names.For each user print each contest with the points in descending order.


            foreach (var item in contestsByUser.OrderBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var kvp in pointsByContest.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"# {kvp.Key} ->{kvp.Value}");
                }
            }
        }
    }
}
