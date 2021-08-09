using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int FirePotionnWeight = 5;
        public FirePotion()
            : base(FirePotionnWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
