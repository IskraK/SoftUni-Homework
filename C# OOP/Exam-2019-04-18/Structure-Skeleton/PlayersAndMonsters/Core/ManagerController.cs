namespace PlayersAndMonsters.Core
{
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;
        private ICardRepository cardRepository;
        private ICardFactory cardFactory;
        private IBattleField battleField;

        public ManagerController(IPlayerRepository playerRepository, IPlayerFactory playerFactory, ICardRepository cardRepository, ICardFactory cardFactory, IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.playerFactory = playerFactory;
            this.cardRepository = cardRepository;
            this.cardFactory = cardFactory;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);
            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Players.FirstOrDefault(p => p.Username == username);
            ICard card = cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            return $"Successfully added card: {cardName} to user: {player.Username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacer = playerRepository.Find(attackUser);
            IPlayer enemy = playerRepository.Find(enemyUser);
            
            this.battleField.Fight(attacer, enemy);
            return $"Attack user health {attacer.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
            sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
