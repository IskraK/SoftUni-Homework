using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacityOfElevator = int.Parse(Console.ReadLine());
            int numberOfCourses = 0;
            if (numberOfPeople % capacityOfElevator == 0)
            {
            numberOfCourses = numberOfPeople / capacityOfElevator ;
            }
            else
            {
                numberOfCourses = numberOfPeople / capacityOfElevator+1;
            }
            Console.WriteLine(numberOfCourses);
        }
    }
}
