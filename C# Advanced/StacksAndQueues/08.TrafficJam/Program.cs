using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passingCars=int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < passingCars; i++)
                    {
                        if (cars.Any())
                        {
                            string currentCar = cars.Dequeue();
                            Console.WriteLine($"{currentCar} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
