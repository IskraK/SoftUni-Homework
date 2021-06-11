using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            List<Person> sortedPeople = people
                .Where(n => n.Age > 30)
                .OrderBy(n => n.Name).ToList();

            foreach (var item in sortedPeople)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
