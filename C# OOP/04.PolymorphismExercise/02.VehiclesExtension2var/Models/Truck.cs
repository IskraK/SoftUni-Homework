using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const bool isSummer = true;
        
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            if (isSummer)
            {
                FuelConsumption += 1.6;
            }
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount);
            FuelQuantity -= fuelAmount * 0.05;
        }
    }
    
}
