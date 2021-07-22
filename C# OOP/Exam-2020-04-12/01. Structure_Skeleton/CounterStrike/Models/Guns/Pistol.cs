using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private int firedBullets = 1;
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (BulletsCount - firedBullets >= 0)
            {
                BulletsCount -= firedBullets;
                return firedBullets;
            }
            else
            {
                BulletsCount = 0;
                return 0;
            }
        }
    }
}
