using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            terrorists = new List<IPlayer>();
            counterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
                else if (player is CounterTerrorist)
                {
                    counterTerrorists.Add(player);
                }
            }

            while (IsTeamAlive(terrorists) && IsTeamAlive(counterTerrorists))
            {
                BattleTeams(terrorists,counterTerrorists);
                BattleTeams(counterTerrorists,terrorists);
            }

            if (IsTeamAlive(counterTerrorists))
            {
                return "Counter Terrorist wins!";
            }
            else if (IsTeamAlive(terrorists))
            {
                return "Terrorist wins!";
            }

            return "Something is wrong";
        }

        private bool IsTeamAlive(ICollection<IPlayer> players)
        {
            return players.Any(p => p.IsAlive);
        }
        private void BattleTeams(List<IPlayer> attackingTeam,List<IPlayer> deffendingTeam)
        {
            foreach (var attacker in attackingTeam)
            {
                //if (!attacker.IsAlive)
                //{
                //    continue;
                //}

                foreach (var deffender in deffendingTeam)
                {
                    if (deffender.IsAlive)
                    {
                        deffender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }
    }
}
