using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuel = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car(model, fuel, fuelConsumption);
                cars.Add(model, car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdParts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = cmdParts[1];
                double distance = double.Parse(cmdParts[2]);

                cars[carModel].CanDrive(distance);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }
        }
    }
}
