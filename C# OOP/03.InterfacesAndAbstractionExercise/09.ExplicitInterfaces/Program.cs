using System;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string country = info[1];
                int age = int.Parse(info[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                person.GetName();
                resident.GetName();

                input = Console.ReadLine();
            }
        }
    }
}
