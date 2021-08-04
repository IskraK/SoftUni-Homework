using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            ModifyBeginnerPlayer(attackPlayer);
            ModifyBeginnerPlayer(enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                int attackerTotalDamagePoints = 0;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    attackerTotalDamagePoints += card.DamagePoints;
                }

                enemyPlayer.TakeDamage(attackerTotalDamagePoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                int enemyTotalDamagePoints = 0;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    enemyTotalDamagePoints += card.DamagePoints;
                }

                attackPlayer.TakeDamage(enemyTotalDamagePoints);
            }
        }

        private static void ModifyBeginnerPlayer(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")  // if (player is Beginner)
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
