using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;
        }

        public double FuelQuantity 
        { 
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                    fuelQuantity = value;
            }
        }
        //public double FuelConsumption { get; protected set; }
        //public double TankCapacity { get; private set; }
        public void Drive(double distance)
        {
            if (FuelQuantity >= distance*fuelConsumption)
            {
                FuelQuantity -= distance * fuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (tankCapacity >= FuelQuantity + fuel)
            {
                FuelQuantity += fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
