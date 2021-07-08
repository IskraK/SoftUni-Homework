using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> citizensAndRebels = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string group = info[2];

                    Rebel rebel = new Rebel(name, age, group);

                    citizensAndRebels.Add(rebel);
                }
                else if (info.Length == 4)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    string birthdate = info[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    citizensAndRebels.Add(citizen);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                IBuyer citizenOrRebel = citizensAndRebels.FirstOrDefault(n => n.Name == input);
                if (citizenOrRebel != null)
                {
                citizenOrRebel.BuyFood();
                }

                input = Console.ReadLine();
            }

            int totalFood = citizensAndRebels.Sum(n => n.Food);
            Console.WriteLine(totalFood);
        }
    }
}
