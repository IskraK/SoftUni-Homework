using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        { 
            get
            {
                return fuelQuantity;
            }
        }

        public void Drive(double distance)
        {
            if (fuelQuantity >= distance*fuelConsumption)
            {
                fuelQuantity -= distance * fuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual double Refuel(double fuel)
        {
            return fuelQuantity +=fuel;
        }
    }
}
