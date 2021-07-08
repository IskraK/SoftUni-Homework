using System;
using System.Collections.Generic;

namespace _04.BorderControl2var
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> ids = new List<string>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];

                if (info.Length == 3)
                {
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    ids.Add(id);
                }
                else if (info.Length == 2)
                {
                    string id = info[1];
                    ids.Add(id);
                }

                input = Console.ReadLine();
            }

            string lastIdSymbols = Console.ReadLine();

            foreach (var item in ids)
            {
                if (item.EndsWith(lastIdSymbols))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
