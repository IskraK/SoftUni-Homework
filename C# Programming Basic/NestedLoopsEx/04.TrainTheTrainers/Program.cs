using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jouryCount = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int marksCount = 0;
            double sumOfAllMarks = 0;
            while (input != "Finish")
            {
                double sumMarks = 0;
                for (int i = 1; i <= jouryCount; i++)
                {
                double mark = double.Parse(Console.ReadLine());
                    sumMarks += mark;
                    marksCount++;
                    sumOfAllMarks += mark;
                }
                double average = sumMarks / jouryCount;
                Console.WriteLine($"{input} - {average:f2}.");
                input = Console.ReadLine();
            }
            double finalAverage = sumOfAllMarks / marksCount;
            Console.WriteLine($"Student's final assessment is {finalAverage:f2}.");
        }
    }
}
