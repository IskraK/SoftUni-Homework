using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineInfo[0];
                int enginePower = int.Parse(engineInfo[1]);
                Engine engine = new Engine(engineModel, enginePower);

                if (engineInfo.Length == 4)
                {
                    engine.Displacement = engineInfo[2];
                    engine.Efficiency = engineInfo[3];
                }
                else if (engineInfo.Length == 3)
                {
                    if (int.TryParse(engineInfo[2],out int result))
                    {
                        engine.Displacement = engineInfo[2];
                    }
                    else
                    {
                        engine.Efficiency = engineInfo[2];
                    }
                }

                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];
                Car car = new Car(carModel, engines.FirstOrDefault(e => e.EngineModel == carInfo[1]));

                if (carInfo.Length == 4)
                {
                    car.Weight = carInfo[2];
                    car.Color = carInfo[3];
                }
                else if (carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2],out int res))
                    {
                        car.Weight = carInfo[2];
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
