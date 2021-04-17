using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.NeedForSpeed3var2Class
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carData[0];
                int mileage = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);

                Car car = new Car(carModel,mileage,fuel);
                car.Mileage = mileage;
                car.Fuel = fuel;
                cars.Add(car);
            }

            string line = Console.ReadLine();

            while (line != "Stop")
            {
                string[] parts = line.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string model = parts[1];
                Car car = cars.FirstOrDefault(c => c.CarModel == model);

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(parts[2]);
                        int neededFuel = int.Parse(parts[3]);

                        if (car.Fuel < neededFuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            car.Mileage += distance;
                            car.Fuel -= neededFuel;
                            Console.WriteLine($"{model} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");
                        }

                        if (car.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {model}!");
                            cars.Remove(car);
                        }
                        break;
                    case "Refuel":
                        int fuel = int.Parse(parts[2]);

                        if (car.Fuel + fuel > 75)
                        {
                            fuel = 75 - car.Fuel;
                        }
                        car.Fuel += fuel;

                        Console.WriteLine($"{model} refueled with {fuel} liters");
                        break;
                    case "Revert":
                        int revertedKm = int.Parse(parts[2]);
                        if (car.Mileage - revertedKm > 10000)
                        {
                            car.Mileage -= revertedKm;
                            Console.WriteLine($"{model} mileage decreased by {revertedKm} kilometers");
                        }
                        else
                        {
                            car.Mileage = 10000;
                        }
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            cars = cars
                .OrderByDescending(c => c.Mileage)
                .ThenBy(c => c.CarModel)
                .ToList();

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.CarModel} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }

    internal class Car
    {
        public Car(string carModel,int mileage,int fuel)
        {
            CarModel = carModel;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string CarModel { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

    }
}
