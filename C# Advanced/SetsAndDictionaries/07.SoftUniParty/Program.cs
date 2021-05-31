using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipList = new HashSet<string>();
            HashSet<string> regularList = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipList.Add(input);
                    }
                    else
                    {
                        regularList.Add(input);
                    }
                }

                input = Console.ReadLine();
            }

            string guest = Console.ReadLine();

            while (guest != "END")
            {
                if (guest.Length == 8)
                {
                    if (char.IsDigit(guest[0]))
                    {
                        if (vipList.Contains(guest))
                        {
                            vipList.Remove(guest);
                        }
                    }
                    else
                    {
                        if (regularList.Contains(guest))
                        {
                            regularList.Remove(guest);
                        }
                    }
                }

                guest = Console.ReadLine();
            }

            Console.WriteLine($"{vipList.Count + regularList.Count}");
            if (vipList.Count > 0)
            {
            Console.WriteLine(string.Join(Environment.NewLine, vipList));
            }
            Console.WriteLine(string.Join(Environment.NewLine, regularList));
        }
    }
}
