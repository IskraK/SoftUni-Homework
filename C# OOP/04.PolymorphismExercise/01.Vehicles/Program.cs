using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            double carFuel = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            Vehicle car = new Car(carFuel,carFuelConsumption);

            double truckFuel = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            Vehicle truck = new Truck(truckFuel, truckFuelConsumption);

            for (int i = 0; i < n; i++)
            {
                string[] cmdParts = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string command = cmdParts[0];
                string typeVehicle = cmdParts[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(cmdParts[2]);

                    if (typeVehicle == "Car")
                    {
                        car.Drive(distance);
                    }
                    else
                    {
                        truck.Drive(distance);
                    }
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(cmdParts[2]);

                    if (typeVehicle == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
