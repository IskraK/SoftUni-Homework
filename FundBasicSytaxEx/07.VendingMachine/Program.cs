using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            const double priceForNuts = 2;
            const double priceForWater = 0.7;
            const double priceForCrisps = 1.5;
            const double priceForSoda = 0.8;
            const double priceForCoke = 1.0;
                //“Nuts”, “Water”, “Crisps”, “Soda”, “Coke”
                //2.0,      0.7,     1.5,     0.8,     1.0
            string input = Console.ReadLine();
            double money = 0;
            while (input != "Start")
            {
                double coins = double.Parse(input);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    money += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine();
            }
            if (input == "Start")
            {
                while (input != "End")
                {
                    input = Console.ReadLine();
                    if (input == "Nuts")
                    {
                        money -= priceForNuts;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += priceForNuts;
                        }

                    }
                    else if (input == "Water")
                    {
                        money -= priceForWater;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += priceForWater;
                        }
                    }
                    else if (input == "Crisps")
                    {
                        money -= priceForCrisps;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += priceForCrisps;
                        }
                    }
                    else if (input == "Soda")
                    {
                        money -= priceForSoda;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += priceForSoda;
                        }
                    }
                    else if (input == "Coke")
                    {
                        money -= priceForCoke;
                        if (money >= 0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            money += priceForCoke;
                        }
                    }
                    else if (input == "End")
                    {
                        Console.WriteLine($"Change: {money:f2}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid product");
                    }
                }
                
            }
        }
    }
}
