using System;

namespace Vehicles.Contracts
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            if (fuelQuantity <= tankCapacity)
            {
                FuelQuantity = fuelQuantity;
            }
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; } //litters per km

        public int TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            if (FuelConsumption * distance > FuelQuantity)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= FuelConsumption * distance;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuelAmount + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                FuelQuantity += fuelAmount;
            }
        }
    }
}
