using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] peopleInWagon = new int[numberOfWagons];
            int totalPeople = 0;

            for (int i = 0; i < peopleInWagon.Length; i++)
            {
                peopleInWagon[i] = int.Parse(Console.ReadLine());
                totalPeople += peopleInWagon[i];
            }

            Console.WriteLine(string.Join(' ',peopleInWagon));
            Console.WriteLine(totalPeople);
        }
    }
}
