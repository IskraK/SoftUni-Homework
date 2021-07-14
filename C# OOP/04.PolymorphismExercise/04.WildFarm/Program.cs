using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                Animal animal = default;

                if (animalType == "Cat")
                {
                    animal = new Cat(name, weight, animalInfo[3], animalInfo[4]);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(name, weight, animalInfo[3], animalInfo[4]);
                }
                else if (animalType == "Dog")
                {
                    animal = new Dog(name, weight, animalInfo[3]);
                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(name, weight, animalInfo[3]);
                }
                else if (animalType == "Hen")
                {
                    animal = new Hen(name, weight, double.Parse(animalInfo[3]));
                }
                else if (animalType == "Owl")
                {
                    animal = new Owl(name, weight, double.Parse(animalInfo[3]));
                }

                Food food = default;

                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(foodQuantity);
                }

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine,animals));
        }
    }
}
