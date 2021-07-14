using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private bool isEmpty = true;
        private readonly double initialFuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            initialFuelConsumption = fuelConsumption;
        }

        public override string Drive(double distance)
        {
            if (isEmpty)
            {
                FuelConsumption = initialFuelConsumption + 1.4;
                isEmpty = false;
            }
            return base.Drive(distance);
        }

        public string DriveEmpty(double distance)
        {
            FuelConsumption = initialFuelConsumption;
            isEmpty = true;

            return base.Drive(distance);
        }
    }
}
