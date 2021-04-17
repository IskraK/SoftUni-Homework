using System;

namespace _06.PassengersPerFlight
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberAirlines = int.Parse(Console.ReadLine());
            double avgPassenger = 0;
            double maxPassenger = 0;
            string maxPassAirline = "";
            for (int i = 1; i <= numberAirlines; i++)
            {
                int counter = 0;
                int totalPassengers = 0;
                string name = Console.ReadLine();
                string input = Console.ReadLine();
                while (input != "Finish")
                {
                    int passengers = int.Parse(input);
                    counter++;
                    totalPassengers += passengers;
                    input = Console.ReadLine();
                }
                avgPassenger = Math.Floor(1.0 * totalPassengers / counter);
                Console.WriteLine($"{name}: {avgPassenger} passengers.");
                if (avgPassenger > maxPassenger)
                {
                    maxPassenger = avgPassenger;
                    maxPassAirline = name;
                }
            }
            Console.WriteLine($"{maxPassAirline} has most passengers per flight: {maxPassenger}");
        }
    }
}
