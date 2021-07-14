using Vehicles.Contracts;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const bool isSummer = true;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            if (isSummer)
            {
                FuelConsumption += 0.9;
            }
        }
    }
}
