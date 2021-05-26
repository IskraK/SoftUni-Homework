using System;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] warShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxHealth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Retire")
            {
                string[] line = input.Split();
                string command = line[0];

                switch (command)
                {
                    case "Fire":
                        int index = int.Parse(line[1]);
                        int damage = int.Parse(line[2]);
                        if (index >= 0 && index < warShip.Length)
                        {
                            warShip[index] -= damage;

                            if (warShip[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(line[1]);
                        int endIndex = int.Parse(line[2]);
                        damage = int.Parse(line[3]);

                        if (startIndex >= 0 && startIndex <= endIndex &&  endIndex < pirateShip.Length )
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damage;

                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        index = int.Parse(line[1]);
                        int health = int.Parse(line[2]);
                        if (index >= 0 && index < pirateShip.Length)
                        {
                                pirateShip[index] += health;

                                if (pirateShip[index] > maxHealth)
                                {
                                    pirateShip[index] = maxHealth;
                                }
                        }
                            break;
                    case "Status":
                        int count = 0;
                        foreach (var item in pirateShip)
                        {
                            if (item < 0.2 * maxHealth)
                            {
                                count++;
                            }
                        }
                        Console.WriteLine($"{count} sections need repair.");
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}
