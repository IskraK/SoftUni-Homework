using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parking = new HashSet<string>();

            while (input != "END")
            {
                string[] parts = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string car = parts[1];

                if (command == "IN")
                {
                    parking.Add(car);
                }
                else
                {
                    parking.Remove(car);
                }

                input = Console.ReadLine();
            }


            if (parking.Count > 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
