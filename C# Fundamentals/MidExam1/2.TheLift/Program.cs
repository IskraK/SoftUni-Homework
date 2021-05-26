using System;
using System.Linq;

namespace _2.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4 && people > 4-wagons[i])
                {
                    people -= 4 - wagons[i];
                    wagons[i] += 4 - wagons[i];
                }
                else if (wagons[i] < 4 && people <= 4-wagons[i] && people > 0)
                {
                    wagons[i] += people;
                    people =0;
                }
                else if (people <= 0)
                {
                    break;
                }
            }

            bool isFull = true;

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4)
                {
                    isFull = false;
                    break;
                }
            }

            if (people > 0 && isFull == true)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ",wagons));
            }
            else if (people <= 0 && isFull == false)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else if (people <= 0 && isFull == true)
            {
                Console.WriteLine(string.Join(" ", wagons));
            }
        }
    }
}
