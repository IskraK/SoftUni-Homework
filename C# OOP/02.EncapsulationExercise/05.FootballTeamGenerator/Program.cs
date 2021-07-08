using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] cmdParts = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdParts[0];
                string teamName = cmdParts[1];
                string playerName = default;

                switch (command)
                {
                    case "Team":
                        teams.Add(new Team(teamName));
                        break;
                    case "Add" when teams.Any(t => t.Name == teamName):
                        playerName = cmdParts[2];
                        int endurance = int.Parse(cmdParts[3]);
                        int sprint = int.Parse(cmdParts[4]);
                        int dribble = int.Parse(cmdParts[5]);
                        int passing = int.Parse(cmdParts[6]);
                        int shooting = int.Parse(cmdParts[7]);

                        try
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams.First(t => t.Name == teamName).AddPlayer(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Remove" when teams.Any(t => t.Name == teamName):
                        playerName = cmdParts[2];
                        try
                        {
                            teams.First(t => t.Name == teamName).RemovePlayer(playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Rating" when teams.Any(t => t.Name == teamName):
                        Team team = teams.First(t => t.Name == teamName);
                        Console.WriteLine($"{teamName} - {team.GetTeamRating}");
                        break;
                    default:
                        Console.WriteLine($"Team {teamName} does not exist.");
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
