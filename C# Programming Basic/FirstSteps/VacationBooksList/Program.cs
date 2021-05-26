using System;

namespace VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Брой страници в текущата книга – цяло число в интервала[1…1000];
            //2.Страници, които може да прочита за 1 час – реално число в интервала[1.00…1000.00];
            //3.Броя на дните, за които трябва да прочете книгата – цяло число в интервала[1…1000];
            int pagesInBook = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());
            double totalBookTime = pagesInBook / pagesPerHour;
            double hoursPerDay = totalBookTime / numberOfDays;
            Console.WriteLine(hoursPerDay);
        }
    }
}
