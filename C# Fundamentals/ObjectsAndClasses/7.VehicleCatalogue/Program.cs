using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.VehicleCatalogue
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Horsepower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Horsepower}hp";
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();


            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] vehicleParts = input.Split("/", StringSplitOptions.RemoveEmptyEntries);
                string type = vehicleParts[0];
                string brand = vehicleParts[1];
                string model = vehicleParts[2];

                if (type == "Car")
                {
                    int horsepower = int.Parse(vehicleParts[3]);
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        Horsepower = horsepower
                    };

                    cars.Add(car);
                }
                else
                {
                    int weight = int.Parse(vehicleParts[3]);
                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };

                    trucks.Add(truck);
                }

                input = Console.ReadLine();
            }

            List<Car> sortedCars = cars.OrderBy(x => x.Brand).ToList();
            List<Truck> sortedTrucks = trucks.OrderBy(x => x.Brand).ToList();

            if (sortedCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in sortedCars)
                {
                    Console.WriteLine(car);
                }
            }

            if (sortedTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in sortedTrucks)
                {
                    Console.WriteLine(truck);
                }
            }
        }
    }
}
