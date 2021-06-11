using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person(20);
            Person personOne = new Person("Pesho",20);
            Person personTwo = new Person("Gosho", 18);
            Person personThree = new Person
            {
                Name = "Stamat",
                Age = 43
            };
        }
    }
}
