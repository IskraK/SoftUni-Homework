using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;
            bool crash = false;
            char hitChar = ' ';

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    int greenTime = greenLightSeconds;

                    while (cars.Count > 0 && greenTime > 0)
                    {
                        string currCar = cars.Peek();

                        if (currCar.Length <= greenTime)
                        {
                            cars.Dequeue();
                            passedCars++;
                            greenTime -= currCar.Length;
                        }
                        else
                        {
                            if (currCar.Length <= greenTime + freeWindowSeconds)
                            {
                                cars.Dequeue();
                                passedCars++;
                                greenTime -= currCar.Length;
                            }
                            else
                            {
                                crash = true;
                                hitChar = currCar[greenTime + freeWindowSeconds];
                            }
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{cars.Peek()} was hit at {hitChar}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
            // 100/100 but Zero Test 2 - Incorrect Answer
        }
    }
}
