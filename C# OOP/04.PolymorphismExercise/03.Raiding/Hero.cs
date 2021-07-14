using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class Hero
    {
        public Hero(string name,int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; }
        public int Power { get; }
        public abstract string CastAbility();
    }
}
