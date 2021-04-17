using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.HeroesOfCodeAnd_LogicVII3var2Dict
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());

            var nameHp = new Dictionary<string, int>();
            var nameMp = new Dictionary<string, int>();

            for (int i = 0; i < times; i++)
            {
                var name = Console.ReadLine().Split().ToArray();

                nameHp[name[0]] = int.Parse(name[1]);
                nameMp[name[0]] = int.Parse(name[2]);

            }

            var command = Console.ReadLine().Split(" - ").ToArray();

            while (command[0] != "End")
            {
                if (command[0] == "CastSpell")
                {
                    //CastSpell – {hero name} – {MP needed} – {spell name} 
                    int mpNeeded = int.Parse(command[2]);

                    if (nameMp[command[1]] < mpNeeded)
                    {
                        Console.WriteLine($"{command[1]} does not have enough MP to cast {command[3]}!");
                    }
                    else
                    {
                        nameMp[command[1]] -= mpNeeded;
                        int points = nameMp[command[1]];
                        Console.WriteLine($"{command[1]} has successfully cast {command[3]} and now has {points} MP!");
                    }
                }
                if (command[0] == "TakeDamage")
                {
                    //TakeDamage – {hero name} – {damage} – {attacker}
                    int damage = int.Parse(command[2]);

                    nameHp[command[1]] -= damage;

                    if (nameHp[command[1]] <= 0)
                    {
                        Console.WriteLine($"{command[1]} has been killed by {command[3]}!");
                        nameHp.Remove(command[1]);
                    }
                    else
                    {
                        int current = nameHp[command[1]];
                        Console.WriteLine($"{command[1]} was hit for {damage} HP by {command[3]} and now has {current} HP left!");
                    }

                }
                if (command[0] == "Recharge")
                {
                    //Recharge – {hero name} – {amount}
                    int amount = int.Parse(command[2]);
                    int old = nameMp[command[1]];
                    nameMp[command[1]] += amount;
                    if (nameMp[command[1]] > 200)
                    {
                        nameMp[command[1]] = 200;
                        amount = 200 - old;
                    }

                    Console.WriteLine($"{command[1]} recharged for {amount} MP!");
                }
                if (command[0] == "Heal")
                {
                    //Heal – {hero name} – {amount}
                    int amount = int.Parse(command[2]);
                    int old = nameHp[command[1]];
                    nameHp[command[1]] += amount;
                    if (nameHp[command[1]] > 100)
                    {
                        nameHp[command[1]] = 100;
                        amount = 100 - old;
                    }

                    Console.WriteLine($"{command[1]} healed for {amount} HP!");
                }

                command = Console.ReadLine().Split(" - ").ToArray();
            }

            Console.WriteLine(string.Join($"{Environment.NewLine}", nameHp
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key}{Environment.NewLine}  HP: {x.Value}{Environment.NewLine}  MP: {nameMp[x.Key]}")));
        }
    }
}
