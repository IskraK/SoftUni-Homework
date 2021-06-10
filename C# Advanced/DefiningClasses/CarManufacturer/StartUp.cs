using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //2.Car Extension

            //Car car = new Car();
            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;

            //car.Drive(2000);

            ////Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");

            //Console.WriteLine(car.WhoAmI());


            //3.Car Constructors

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);


            //4.Car Engine and Tires

            //Tire[] tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //};

            //Engine engine = new Engine(560, 6300);
            //Car car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);


            //5.Special Cars

            List<Tire[]> tires = new List<Tire[]>();
            string tireInfo = Console.ReadLine();

            while (tireInfo != "No more tires")
            {
                string[] tireParts = tireInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tireParts[0]),double.Parse(tireParts[1])),
                    new Tire(int.Parse(tireParts[2]),double.Parse(tireParts[3])),
                    new Tire(int.Parse(tireParts[4]),double.Parse(tireParts[5])),
                    new Tire(int.Parse(tireParts[6]),double.Parse(tireParts[7])),
                };

                tires.Add(currentTires);

                tireInfo = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            string engineInfo = Console.ReadLine();

            while (engineInfo != "Engines done")
            {
                string[] engineParts = engineInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineParts[0]);
                double cubicCapacity = double.Parse(engineParts[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);


                engineInfo = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();
            string carInfo = Console.ReadLine();

            while (carInfo != "Show special")
            {
                string[] carParts = carInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carParts[0];
                string model = carParts[1];
                int year = int.Parse(carParts[2]);
                double fuelQuantity = double.Parse(carParts[3]);
                double fuelConsumption = double.Parse(carParts[4]);
                int engineIndex = int.Parse(carParts[5]);
                int tireIndex = int.Parse(carParts[6]);
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);
                cars.Add(car);

                carInfo = Console.ReadLine();
            }

            List<Car> specialCars = cars
                .Where(car => car.Year >= 2017 && car.Engine.HorsePower > 330
                && car.Tires.Sum(y => y.Pressure) >= 9 && car.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();

            if (cars.Any())
            {
                foreach (var car in specialCars)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }

            }

        }
    }
}
