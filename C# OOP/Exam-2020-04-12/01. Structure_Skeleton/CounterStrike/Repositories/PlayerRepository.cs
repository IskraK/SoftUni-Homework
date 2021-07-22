using System;
using System.Collections.Generic;
using System.Linq;

using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();      
        }
        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            players.Add(player);
        }

        public IPlayer FindByName(string name)
        {
            IPlayer player = players.FirstOrDefault(p => p.Username == name);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            return players.Remove(player);
        }
    }
}
