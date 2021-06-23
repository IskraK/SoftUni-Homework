using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {

        private readonly List<Player> players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            players = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return players.Count; } }

        public void AddPlayer(Player player)
        {
            if (Capacity > Count)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (players.Any(p => p.Name == name))
            {
                Player playerToRemove = players.FirstOrDefault(p => p.Name == name);
                players.Remove(playerToRemove);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            if (players.Any(p => p.Name == name))
            {
                Player playerToPromote = players.FirstOrDefault(p => p.Name == name);
                if (playerToPromote.Rank == "Trial")
                {
                    playerToPromote.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = players.FirstOrDefault(p => p.Name == name);
            if (playerToDemote.Rank == "Member")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] newClass = players.Where(p => p.Class == @class).ToArray();
            foreach (var player in newClass)
            {
                if (players.Contains(player))
                {
                    players.Remove(player);
                }
            }
            return newClass;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
