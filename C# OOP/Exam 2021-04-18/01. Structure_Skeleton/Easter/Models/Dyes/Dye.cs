﻿using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power; 
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                this.power = value;
            }
        }

        public bool IsFinished()
        {
            if (this.Power <= 0)
            {
                return true;
            }
            return false;
        }

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
