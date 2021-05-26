using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] data = input.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string hatColor = data[1];
                int physics = int.Parse(data[2]);

                Dwarf repeat = dwarfs.Find(x => x.Name == name && x.HatColor == hatColor);

                if (repeat == null)
                {
                    Dwarf dwarf = new Dwarf(name, hatColor, physics);
                    dwarfs.Add(dwarf);
                }
                else
                {
                    repeat.Physics = Math.Max(repeat.Physics, physics);
                }

                input = Console.ReadLine();
            }

            List<Dwarf> sortedDwarfs = dwarfs
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => dwarfs.Count(y => y.HatColor == x.HatColor))
                .ToList();

            foreach (var dwarf in sortedDwarfs)
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }

    public class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }

        public Dwarf(string name,string hatColor, int physics)
        {
            Name = name;
            HatColor = hatColor;
            Physics = physics;
        }
    }
}
