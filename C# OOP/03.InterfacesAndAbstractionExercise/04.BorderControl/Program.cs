using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> citizensAndRobots = new List<IIdentifiable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];

                if (info.Length == 3)
                {
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    IIdentifiable citizen = new Citizen(name,age,id);
                    citizensAndRobots.Add(citizen);
                }
                else if(info.Length == 2)
                {
                    string id = info[1];
                    IIdentifiable robot = new Robot(name, id);
                    citizensAndRobots.Add(robot);
                }

                input = Console.ReadLine();
            }

            string lastIdSymbols = Console.ReadLine();

            foreach (var item in citizensAndRobots)
            {
                if (item.Id.EndsWith(lastIdSymbols))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
