using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                string[] animalInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                if (age > 0)
                {
                    Animal animal;

                    if (animalType == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                        Console.WriteLine(animal);
                    }
                    else if (animalType == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                        Console.WriteLine(animal);
                    }
                    else if (animalType == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                        Console.WriteLine(animal);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(name, age);
                        Console.WriteLine(animal);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                        Console.WriteLine(animal);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }
    }
}
