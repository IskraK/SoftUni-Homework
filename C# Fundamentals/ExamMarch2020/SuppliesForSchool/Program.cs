using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Пакет химикали -5.80 лв
            //•	Пакет маркери -7.20 лв
            //•	Препарат - 1.20 лв(за литър)
            //    •	Първи ред -брой пакети химикали. Цяло число в интервала[0...100]
            //    •	Втори ред -брой пакети маркери. Цяло число в интервала[0...100]
            //    •	Трети ред -литър препарат за почистване на дъска.Реално число в интервала[0.00…50.00]
            //    •	Четвърти ред -процентът намаление.Цяло число в интервала[0...100]
            const double pricePacketPens = 5.80;
            const double pricePacketMarkers = 7.20;
            const double priceLiterCleaner = 1.20;
            int numberPacketsPen = int.Parse(Console.ReadLine());
            int numberPacketsMarker = int.Parse(Console.ReadLine());
            double litresCleaner = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());
            double sumForMatherials = numberPacketsPen * pricePacketPens + numberPacketsMarker * pricePacketMarkers + priceLiterCleaner * litresCleaner;
            double totalSum = sumForMatherials * (1 - discount / 100);
            Console.WriteLine($"{totalSum:f3}");
        }
    }
}
