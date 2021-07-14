using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : Hero
    {
        private const int heroPower = 80;
        public Druid(string name) 
            : base(name, heroPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
