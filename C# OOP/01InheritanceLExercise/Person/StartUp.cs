using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            //Child child = new Child(name, age);
            //Console.WriteLine(child);

            Person person;
            if (age <= 15)
            {
                person = new Child(name, age);
            }
            else
            {
                person = new Person(name, age);
            }

            Console.WriteLine(person);
        }
    }
}