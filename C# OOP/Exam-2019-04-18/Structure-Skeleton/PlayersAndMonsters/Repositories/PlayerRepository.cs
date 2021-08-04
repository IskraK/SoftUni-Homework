using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> playerRepository;

        public PlayerRepository()
        {
            this.playerRepository = new List<IPlayer>();
        }
        public int Count => this.playerRepository.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playerRepository.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (playerRepository.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            playerRepository.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = playerRepository.FirstOrDefault(p => p.Username == username);
            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return playerRepository.Remove(player);
        }
    }
}
