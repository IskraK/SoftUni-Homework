using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> cars;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return cars.Count;
            }
        }

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (cars.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                Car removedCar = cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
                cars.Remove(removedCar);
                return true;
            }
            return false;
        }

        public Car GetLatestCar()
        {
            return cars.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
