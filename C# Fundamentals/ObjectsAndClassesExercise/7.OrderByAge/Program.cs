using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.OrderByAge
{
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] personeData = line.Split();
                string name = personeData[0];
                string id = personeData[1];
                int age = int.Parse(personeData[2]);

                Person person = new Person
                {
                    Name = name,
                    Id = id,
                    Age = age
                };

                people.Add(person);

                line = Console.ReadLine();
            }

            List<Person> sortedPeople = people.OrderBy(x => x.Age).ToList();

            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }
}
