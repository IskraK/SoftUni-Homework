using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AdditionalFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AdditionalFuelConsumption, tankCapacity)
        {
        }

        public void DriveEmpty(double distance)
        {
            fuelConsumption -= AdditionalFuelConsumption;
            base.Drive(distance);
        }
    }
}
