using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBirthable> citizensAndPets = new List<IBirthable>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = info[0];
                string name = info[1];

                if (type == "Citizen")
                {
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    string birthdate = info[4];
                    Citizen citizen = new Citizen(name,age,id,birthdate);
                    citizensAndPets.Add(citizen);
                }
                else if(type == "Pet")
                {
                    string birthdate = info[2];
                    Pet pet = new Pet(name, birthdate);
                    citizensAndPets.Add(pet);
                }

                input = Console.ReadLine();
            }

            string specificYear = Console.ReadLine();

            foreach (var item in citizensAndPets)
            {
                if (item.Birthdate.EndsWith(specificYear))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
