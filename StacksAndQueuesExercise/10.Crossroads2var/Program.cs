using System;
using System.Collections.Generic;

namespace _10.Crossroads2var
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeOfGreenLight = int.Parse(Console.ReadLine());
            int timeOfFreeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            bool crash = false;
            int passedCars = 0;
            char hitCharacter = ' ';

            string command = Console.ReadLine();
            while (command != "END" && !crash)
            {
                if (command == "green")
                {
                    int greenTime = timeOfGreenLight;

                    while (cars.Count > 0 && greenTime > 0)
                    {
                        string currCar = cars.Peek();
                        if (currCar.Length > greenTime)
                        {
                            if (currCar.Length > greenTime + timeOfFreeWindow)
                            {
                                //crash
                                crash = true;
                                hitCharacter = currCar[greenTime + timeOfFreeWindow];
                            }
                            else
                            {
                                cars.Dequeue();
                                passedCars++;
                            }
                            break;
                        }
                        else
                        {
                            cars.Dequeue();
                            passedCars++;
                            greenTime -= currCar.Length;
                        }
                    }
                }
                else //adding car
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{cars.Peek()} was hit at {hitCharacter}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
