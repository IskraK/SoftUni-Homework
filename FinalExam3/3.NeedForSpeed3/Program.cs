using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cars = new Dictionary<string, int[]>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carData[0];
                int mileage = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);

                cars.Add(carModel, new int[] { mileage, fuel });
            }

            string line = Console.ReadLine();

            while (line != "Stop")
            {
                string[] parts = line.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string car = parts[1];

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(parts[2]);
                        int neededFuel = int.Parse(parts[3]);

                        if (cars[car][1] < neededFuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            cars[car][0] += distance;
                            cars[car][1] -= neededFuel;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");
                        }

                        if (cars[car][0] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(car);
                        }
                        break;
                    case "Refuel":
                        int fuel = int.Parse(parts[2]);

                        if (cars[car][1] + fuel > 75)
                        {
                            fuel = 75 - cars[car][1];
                        }
                        cars[car][1] += fuel;

                        Console.WriteLine($"{car} refueled with {fuel} liters");
                        break;
                    case "Revert":
                        int revertedKm = int.Parse(parts[2]);
                        if (cars[car][0] - revertedKm > 10000)
                        {
                        cars[car][0] -= revertedKm;
                        Console.WriteLine($"{car} mileage decreased by {revertedKm} kilometers");
                        }
                        else
                        {
                            cars[car][0] = 10000;
                        }
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            cars = cars
                .OrderByDescending(m => m.Value[0])
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
