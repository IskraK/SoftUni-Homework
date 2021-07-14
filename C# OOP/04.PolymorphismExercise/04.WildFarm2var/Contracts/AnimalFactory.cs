using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string[] animalInfo)
        {
            string animalType = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

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

            return animal;
        }
    }
}
