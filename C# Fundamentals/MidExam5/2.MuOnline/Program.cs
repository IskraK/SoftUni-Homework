using System;
using System.Linq;

namespace _2.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int health = 100;
            int bitcoins = 0;
            bool isDead = false;

            for (int i = 0; i < input.Length; i++)
            {
                string[] room = input[i].Split().ToArray();
                string command = room[0];
                int amount = int.Parse(room[1]);

                switch (command)
                {
                    case "potion":
                        if (health + amount >= 100)
                        {
                            amount = 100-health;
                            health = 100;
                        }
                        else
                        {
                            health += amount;

                        }
                        Console.WriteLine($"You healed for {amount} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins += amount;
                        Console.WriteLine($"You found {amount} bitcoins.");
                        break;
                    default:
                        health -= amount;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            isDead = true;
                            break;
                        }
                        break;
                }

                if (isDead)
                {
                    break;
                }
            }

            if (health > 0)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
