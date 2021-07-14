using System;
using System.Collections.Generic;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle;

            string[] line = Console.ReadLine().Split();
            string[] lineTwo = Console.ReadLine().Split();
            string[] lineThree = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(line[1]), double.Parse(line[2]), int.Parse(line[3]));
            Vehicle truck = new Truck(double.Parse(lineTwo[1]), double.Parse(lineTwo[2]), int.Parse(lineTwo[3]));
            Vehicle bus = new Bus(double.Parse(lineThree[1]), double.Parse(lineThree[2]), int.Parse(lineThree[3]));

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[1] == "Car")
                {
                    vehicle = car;
                }
                else if (command[1] == "Truck")
                {
                    vehicle = truck;
                }
                else
                {
                    vehicle = bus;
                }

                if (command[0] == "Drive") //Drive
                {
                    Console.WriteLine(vehicle.Drive(double.Parse(command[2])));
                }
                else if (command[0] == "DriveEmpty" && vehicle is Bus)
                {
                    Console.WriteLine(((Bus)vehicle).DriveEmpty(double.Parse(command[2])));
                }
                else //Refuel
                {
                    try
                    {
                        vehicle.Refuel(double.Parse(command[2]));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
