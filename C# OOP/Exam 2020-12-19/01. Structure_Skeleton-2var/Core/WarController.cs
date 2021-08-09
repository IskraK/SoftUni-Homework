using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly List<Character> charactersParty;
		private readonly Stack<Item> items;
		public WarController()
		{
			charactersParty = new List<Character>();
			items = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string characterName = args[1];

			Character character;

			if (characterType == nameof(Warrior))
			{
				character = new Warrior(characterName);
			}
			else if (characterType == nameof(Priest))

			{
				character = new Priest(characterName);
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			charactersParty.Add(character);
			return string.Format(SuccessMessages.JoinParty, characterName);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item;

            if (itemName == nameof(HealthPotion))
            {
				item = new HealthPotion();
			}
			else if (itemName == nameof(FirePotion))
			{
				item = new FirePotion();
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			items.Push(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = charactersParty.FirstOrDefault(c => c.Name == characterName);

            if (character is null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

            if (items.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item item = items.Pop();
			character.Bag.AddItem(item);
			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = charactersParty.FirstOrDefault(c => c.Name == characterName);

			if (character is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

            foreach (var character in charactersParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
				string result = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {result}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = charactersParty.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = charactersParty.FirstOrDefault(c => c.Name == receiverName);

			if (attacker is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			else if (receiver is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			//if (attacker is IHealer)
			//{
			//	throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
			//}

			//(attacker as IAttacker).Attack(receiver);

			Warrior warrior = attacker as Warrior;

			if (warrior is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

			warrior.Attack(receiver);

            StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = charactersParty.FirstOrDefault(c => c.Name == healerName);
			Character receiver = charactersParty.FirstOrDefault(c => c.Name == healingReceiverName);

			if (healer is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			else if (receiver is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}


			//if (healer is IAttacker)
			//{
			//	throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
			//}

			//(healer as IHealer).Heal(receiver);

			Priest priest = healer as Priest;

            if (priest is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

			priest.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
