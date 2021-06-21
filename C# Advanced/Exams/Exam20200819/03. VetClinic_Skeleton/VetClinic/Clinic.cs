using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> pets;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return pets.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (Capacity > Count)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (pets.Any(p => p.Name == name))
            {
                Pet petToRemove = pets.FirstOrDefault(p => p.Name == name);
                pets.Remove(petToRemove);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            return pets.FirstOrDefault(p => p.Name == name && p.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return pets.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
