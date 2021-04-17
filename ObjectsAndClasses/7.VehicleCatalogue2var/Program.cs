using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.VehicleCatalogue2var
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> catalogs = new List<Catalog>();

            string inputLine = Console.ReadLine();
            while (inputLine != "end")
            {
                string[] currLine = inputLine.Split("/");
                string typeOfVehicle = currLine[0];
                string brandOfVehicle = currLine[1];
                string modelOfVehicle = currLine[2];
                Catalog catalog = new Catalog();
                switch (typeOfVehicle)
                {
                    case "Car":
                        int horsePowerOfCar = int.Parse(currLine[3]);
                        Car car = new Car(brandOfVehicle, modelOfVehicle, horsePowerOfCar);
                        catalog = new Catalog(car);
                        break;
                    case "Truck":
                        int weightOfTruck = int.Parse(currLine[3]);
                        Truck truck = new Truck(brandOfVehicle, modelOfVehicle, weightOfTruck);
                        catalog = new Catalog(truck);
                        break;
                    default:
                        break;


                }

                catalogs.Add(catalog);

                inputLine = Console.ReadLine();
            }


            bool isFirstLine = true;
            foreach (Catalog catalog in catalogs.Where(x => x.Car != null).OrderBy(x => x.Car.Brand))
            {
                if (isFirstLine)
                {
                    Console.WriteLine("Cars:");
                    isFirstLine = false;
                }
                string brand = catalog.Car.Brand;
                string model = catalog.Car.Model;
                int horsePower = catalog.Car.HorsePower;
                Console.WriteLine($"{brand}: {model} - {horsePower}hp");
            }

            isFirstLine = true;
            foreach (Catalog catalog in catalogs.Where(x => x.Truck != null).OrderBy(x => x.Truck.Brand))
            {
                if (isFirstLine)
                {
                    Console.WriteLine("Trucks:");
                    isFirstLine = false;
                }
                string brand = catalog.Truck.Brand;
                string model = catalog.Truck.Model;
                int weight = catalog.Truck.Weight;
                Console.WriteLine($"{brand}: {model} - {weight}kg");
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }
    }

    class Catalog
    {
        public Truck Truck { get; set; }
        public Car Car { get; set; }

        public Catalog(Truck truck)
        {
            this.Truck = truck;
        }

        public Catalog(Car car)
        {
            this.Car = car;
        }

        public Catalog()
        {

        }
    }
}
