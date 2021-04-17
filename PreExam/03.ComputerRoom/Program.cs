using System;

namespace _03.ComputerRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред - месецът - текст с възможности: "march", "april", "may", "june", "july", "august"
            //•	На втория ред - броят на прекараните часове - цяло число в диапазона[1...10]
            //•	На третия ред - броят на хората в групата -цяло число в диапазона[1...10]
            //•	На четвъртия ред - времето от деня – текст с възможности: "day", "night"
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string timeDay = Console.ReadLine();
            double pricePerHour = 0;
            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    if (timeDay == "day")
                    {
                        pricePerHour = 10.50;
                    }
                    else
                    {
                        pricePerHour = 8.40;
                    }
                    if (people >= 4)
                    {
                        pricePerHour *= 0.9;
                    }
                    if (hours >= 5)
                    {
                        pricePerHour *= 0.5;
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    if (timeDay == "day")
                    {
                        pricePerHour = 12.60;
                    }
                    else
                    {
                        pricePerHour = 10.20;
                    }
                    if (people >= 4)
                    {
                        pricePerHour *= 0.9;
                    }
                    if (hours >= 5)
                    {
                        pricePerHour *= 0.5;
                    }
                    break;
            }
            double totalPrice = pricePerHour*people*hours;
            Console.WriteLine($"Price per person for one hour: {pricePerHour:f2}");
            Console.WriteLine($"Total cost of the visit: {totalPrice:f2}");
        }
    }
}
