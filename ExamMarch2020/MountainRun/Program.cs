using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Рекордът в секунди – реално число в интервала[0.00 … 100000.00]
            //2.Разстоянието в метри – реално число в интервала[0.00 … 100000.00]
            //3.Времето в секунди, за което изкачва 1 м. – реално число в интервала[0.00 … 1000.00]
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());
            //   наклона на терена го забавя на всеки 50 м.с 30 секунди.Да се изчисли времето в секунди, за което Георги ще изкачи разстоянието до върха и разликата спрямо рекорда.
            //Когато се изчислява колко пъти Георги ще се забави в резултат на наклона на терена, резултатът трябва да се закръгли надолу до най-близкото цяло число.
            //•	Ако Георги е подобрил рекорда отпечатваме:
            //o    " Yes! The new record is {времето на Георги} seconds."
            //•	Ако НЕ е подобрил рекорда отпечатваме:
            //o   "No! He was {недостигащите секунди} seconds slower."
            //Резултатът трябва да се форматира до втория знак след десетичната запетая.
            double timeInSeconds = distance * timeForMeter;
            double delay = Math.Floor(distance / 50) * 30;
            double totalTime = timeInSeconds + delay;
            if (totalTime < record)
            {
                Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                double timeNeeded = totalTime - record;
                Console.WriteLine($"No! He was {timeNeeded:f2} seconds slower.");
            }
        }
    }
}
