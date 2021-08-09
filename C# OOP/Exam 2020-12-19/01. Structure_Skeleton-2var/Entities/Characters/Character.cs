using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;

        protected Character(string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = baseHealth;
            Health = BaseHealth;
            BaseArmor = baseArmor;
            Armor = BaseArmor;
            AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value; 
            }
        }

        public double BaseHealth { get; }

        public double Health { get; set; }

        public double BaseArmor  { get; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; }

        public Bag Bag;

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            this.Armor -= hitPoints;

            if (this.Armor < 0)
            {
                this.Health += this.Armor;
                this.Armor = 0;

                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }


        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
    }
}