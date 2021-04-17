using System;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRestDays = int.Parse(Console.ReadLine());
            const int normaInMinutes = 30000;
            int realTime = (365 - numberRestDays) * 63 + numberRestDays * 127;
            int razlikaTime = Math.Abs(realTime - normaInMinutes);
            int realHours = razlikaTime / 60;
            int realMinutes = razlikaTime % 60;
            //•	Ако времето за игра на Том е над нормата за текущата година:
            //    o На първия ред отпечатайте: “Tom will run away”
            //    o На втория ред отпечатайте разликата от нормата във формат:
            //        “{ H} hours and { M} minutes more for play”
            //•	Ако времето за игра на Том е под нормата за текущата година:
            //    o   На първия ред отпечатайте: “Tom sleeps well”
            //    o    На втория ред отпечатайте разликата от нормата във формат:
            //            “{ H} hours and { M} minutes less for play”
            if (realTime>normaInMinutes)
            {
                Console.WriteLine($"Tom will run away");
                Console.WriteLine($"{realHours} hours and {realMinutes} minutes more for play");
            }
            else
            {
                Console.WriteLine($"Tom sleeps well");
                Console.WriteLine($"{realHours} hours and {realMinutes} minutes less for play");
            }
        }
    }
}
