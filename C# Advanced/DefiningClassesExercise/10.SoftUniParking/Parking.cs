using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        static int capacity;
        public Parking(int capacity)
        {
            Cars = new Dictionary<string, Car>();
            Parking.capacity = capacity;
        }
        public Dictionary<string,Car> Cars { get; set; }
        public int Count { get; set; }


        public string AddCar(Car car)
        {
            if (Cars.ContainsKey(car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }

            if (capacity == Cars.Count)
            {
                return $"Parking is full!";
            }

            Cars.Add(car.RegistrationNumber,car);
            Count++;
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.ContainsKey(registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(registrationNumber);
                Count--;
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                if (Cars.ContainsKey(regNumber))
                {
                    Cars.Remove(regNumber);
                    Count--;
                }
            }
        }
    }
}
