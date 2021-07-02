using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                decimal salary = decimal.Parse(input[3]);
                try
                {
                Person person = new Person(firstName, lastName, age, salary);

                people.Add(person);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            decimal parcentage = decimal.Parse(Console.ReadLine());

            people.ForEach(p => p.IncreaseSalary(parcentage));
            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
