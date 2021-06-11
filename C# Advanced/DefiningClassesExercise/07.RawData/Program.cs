using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
            List<Car> cars = new List<Car>();

             int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int speed = int.Parse(carInfo[1]);
                int power = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tirePressure1 = double.Parse(carInfo[5]);
                int tireAge1 = int.Parse(carInfo[6]);
                double tirePressure2 = double.Parse(carInfo[7]);
                int tireAge2 = int.Parse(carInfo[8]);
                double tirePressure3 = double.Parse(carInfo[9]);
                int tireAge3 = int.Parse(carInfo[10]);
                double tirePressure4 = double.Parse(carInfo[11]);
                int tireAge4 = int.Parse(carInfo[12]);

                Engine carEngine = new Engine(speed, power);
                Cargo carCargo = new Cargo(cargoWeight, cargoType);
                Tire[] carTires = new Tire[4];
                Tire tire1 = new Tire(tirePressure1, tireAge1);
                Tire tire2 = new Tire(tirePressure2, tireAge2);
                Tire tire3 = new Tire(tirePressure3, tireAge3);
                Tire tire4 = new Tire(tirePressure4, tireAge4);
                carTires[0] = tire1;
                carTires[1] = tire2;
                carTires[2] = tire3;
                carTires[3] = tire4;

                Car car = new Car(model, carEngine, carCargo, carTires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars.Where(c => c.CarCargo.CargoType == "fragile")
                    .Where(c => c.CarTires[0].TirePressure <= 1)
                    .ToList();
            }
            else if (command == "flamable")
            {
                cars = cars.Where(c => c.CarCargo.CargoType == "flamable")
                    .Where(c => c.CarEngine.EnginePower > 250)
                    .ToList();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
