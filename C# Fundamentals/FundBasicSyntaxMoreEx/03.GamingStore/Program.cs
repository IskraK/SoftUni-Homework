using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Name            Price
            //OutFall 4       $39.99
            //CS: OG          $15.99
            //Zplinter Zell	$19.99
            //Honored 2       $59.99
            //RoverWatch      $29.99
            //RoverWatch Origins Edition  $39.99

            double balance = double.Parse(Console.ReadLine());
            double moneySpent = 0;
            string game = Console.ReadLine();
            double price = 0;

            while (game != "Game Time")
            {

                if (game == "OutFall 4" || game == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                }
                else if (game == "RoverWatch")
                {
                    price = 29.99;
                }
                else if (game == "Honored 2")
                {
                    price = 59.99;
                }
                else if (game == "Zplinter Zell")
                {
                    price = 19.99;
                }
                else if (game == "CS: OG")
                {
                    price = 15.99;
                }
                else if (game != "OutFall 4" || game != "CS: OG" || game != "Zplinter Zell" || game != "Honored 2" || game != "RoverWatch" || game != "RoverWatch Origins Edition")
                {
                    Console.WriteLine("Not Found");
                }

                if (game == "OutFall 4" || game == "CS: OG" || game == "Zplinter Zell" || game == "Honored 2" || game == "RoverWatch" || game == "RoverWatch Origins Edition")
                {
                    if (balance >= price)
                    {
                        Console.WriteLine($"Bought {game}");
                        balance -= price;
                        moneySpent += price;
                        if (balance == 0)
                        {
                            Console.WriteLine("Out of money!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                game = Console.ReadLine();
            }
            if (game == "Game Time")
            {
                Console.WriteLine($"Total spent: ${moneySpent:f2}. Remaining: ${balance:f2}");
            }
        }
    }
}
