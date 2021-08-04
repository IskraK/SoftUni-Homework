using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly Dictionary<string, ICard> cardRepository;

        public CardRepository()
        {
            this.cardRepository = new Dictionary<string, ICard>();
        }

        public int Count => this.cardRepository.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardRepository.Values.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (cardRepository.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
 
            cardRepository.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (cardRepository.ContainsKey(name))
            {
                card = cardRepository[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return cardRepository.Remove(card.Name);
        }
    }
}
