using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private int firedBullets = 10;
        public Rifle(string name, int bulletsCount)
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
