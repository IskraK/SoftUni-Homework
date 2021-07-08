using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;
        private int rating;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        private int TeamRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }
            return players.Sum(p => p.GetSkillLevel) / players.Count;
        }

        public int GetTeamRating => TeamRating();

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException($"Player {name} is not in {this.Name} team.");
            }

            players.Remove(playerToRemove);
        }
    }
}
