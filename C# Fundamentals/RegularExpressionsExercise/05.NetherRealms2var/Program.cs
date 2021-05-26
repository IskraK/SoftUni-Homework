using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms2var
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();
            string text = Console.ReadLine();
            string[] demonsNames = text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string healthPattern = @"[^0-9+*\/.-]";
            string baseDamagePattern = @"[+-]?(?:(?:\d+\.\d+)|(?:\d+))";
            string damageAlterPattern = @"[*\/]";

            foreach (var demonName in demonsNames)
            {
                int health = 0;
                {
                    var matches = Regex.Matches(demonName, healthPattern);
                    foreach (Match match in matches)
                    {
                        health += match.Value[0];
                    }
                }

                double damage = 0;
                {
                    var matches = Regex.Matches(demonName, baseDamagePattern);
                    foreach (Match match in matches)
                    {
                        damage += double.Parse(match.Value);
                    }
                    var altersSign = Regex.Matches(demonName, damageAlterPattern);
                    foreach (Match match in altersSign)
                    {
                        if (match.Value == "*")
                        {
                            damage *= 2;
                        }
                        else
                        {
                            damage /= 2;
                        }
                    }
                }

                Demon demon = new Demon(demonName, health, damage);
                demons.Add(demon);
            }

            foreach (var demon in demons.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }
    }

    public class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
