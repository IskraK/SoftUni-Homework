using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] personInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());
            Person personToCompare = people[n - 1];
            int countMatches = 0;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    countMatches++;
                }
            }

            if (countMatches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int countNotMatched = people.Count - countMatches;
                Console.WriteLine($"{countMatches} {countNotMatched} {people.Count}");
            }
        }
    }
}
