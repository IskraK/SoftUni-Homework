using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double AdditionalFuelConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + AdditionalFuelConsumption)
        {
        }

        public override double Refuel(double fuel)
        {
            return base.Refuel(fuel * 0.95);
        }
    }
}
