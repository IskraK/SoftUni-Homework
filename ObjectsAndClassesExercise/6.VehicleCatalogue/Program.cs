using System;
using System.Collections.Generic;

namespace _6.VehicleCatalogue
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] vehicleParts = line.Split();
                string type = vehicleParts[0];
                string model = vehicleParts[1];
                string color = vehicleParts[2];
                int horsepower = int.Parse(vehicleParts[3]);

                Vehicle vehicle = new Vehicle
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    Horsepower = horsepower
                };

                vehicles.Add(vehicle);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Close the Catalogue")
                {
                    break;
                }

                Vehicle vehicle = GetVehicleByModel(vehicles, line);

                if (vehicle == null)
                {
                    continue;
                }

                if (vehicle.Type == "car")
                {
                    Console.WriteLine("Type: Car");
                }
                else
                {
                    Console.WriteLine("Type: Truck");
                }

                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
            }

            double carsHorsepowerAvg = CalcAvgHorsepowerByType(vehicles, "car");
            double trucksHorsepowerAvg = CalcAvgHorsepowerByType(vehicles, "truck");

            Console.WriteLine($"Cars have average horsepower of: {carsHorsepowerAvg:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksHorsepowerAvg:F2}.");
        }

        private static double CalcAvgHorsepowerByType(List<Vehicle> vehicles, string type)
        {
            int typeCount = 0;
            int typeHorsepowerSum = 0;

            foreach (var vehicle in vehicles)
            {
                if (vehicle.Type == type)
                {
                    typeCount += 1;
                    typeHorsepowerSum += vehicle.Horsepower;
                }
            }

            if (typeCount == 0)
            {
                return 0;
            }
            return (double)typeHorsepowerSum / typeCount;
        }

        private static Vehicle GetVehicleByModel(List<Vehicle> vehicles, string model)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Model == model)
                {
                    return vehicle;
                }
            }
            return null;
        }
    }
}
