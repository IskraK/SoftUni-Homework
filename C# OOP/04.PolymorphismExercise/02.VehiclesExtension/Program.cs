using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            double carFuel = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            Vehicle car = new Car(carFuel, carFuelConsumption, carTankCapacity);

            double truckFuel = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            Vehicle truck = new Truck(truckFuel, truckFuelConsumption, truckTankCapacity);

            double busFuel = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Bus bus = new Bus(busFuel, busFuelConsumption, busTankCapacity);

            for (int i = 0; i < n; i++)
            {
                string[] cmdParts = Console.ReadLine().Split();
                string command = cmdParts[0];
                string typeVehicle = cmdParts[1];
                double distance = double.Parse(cmdParts[2]);
                double fuel = distance;

                if (command == "Drive")
                {
                    if (typeVehicle == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (typeVehicle == "Truck")
                    {
                        truck.Drive(distance);
                    }
                    else
                    {
                        bus.Drive(distance);
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (typeVehicle == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (typeVehicle == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                        else
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (command == "DriveEmpty" && typeVehicle == "Bus")
                {
                    bus.DriveEmpty(fuel);
                }

                Console.WriteLine($"Car: {car.FuelQuantity:F2}");
                Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
                Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
            }
            // 75/100?
        }
    }
}
