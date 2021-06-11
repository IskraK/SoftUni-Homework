using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model,double fuel,double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuel;
            FuelConsumptionPerKilometer = fuelConsumption;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void CanDrive(double distance)
        {
            if (FuelAmount >= FuelConsumptionPerKilometer * distance)
            {
                FuelAmount -= FuelConsumptionPerKilometer * distance;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive") ;
            }
        }

    }
}
