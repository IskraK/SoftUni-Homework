using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //            •	The amount of money Ivan Cho has – floating - point number in range[0.00…1, 000.00]
            //•	The count of students – integer in range[0…100]
            //•	The price of lightsabers for a single sabre – floating - point number in range[0.00…100.00]
            //•	The price of robes for a single robe – floating - point number in range[0.00…100.00]
            //•	The price of belts for a single belt – floating - point number in range[0.00…100.00]

            double money = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double priceForLightsabers = lightsaberPrice * Math.Ceiling( numberOfStudents*1.1);
            double priceForBelts = 0;
            double priceForRobes = robePrice * numberOfStudents;

            if (numberOfStudents >= 6)
            {
                priceForBelts = beltPrice * (numberOfStudents - numberOfStudents/6); 
            }
            else
            {
                priceForBelts = beltPrice * numberOfStudents;
            }

            double totalPrice = priceForLightsabers + priceForRobes + priceForBelts;

            //            •	If the calculated price of the equipment is less or equal to the money Ivan Cho has:
            //            o   "The money is enough - it would cost {the cost of the equipment}lv."
            //•	If the calculated price of the equipment is more than the money Ivan Cho has:
            //            o    "Ivan Cho will need {neededMoney}lv more."
            //•	All prices must be rounded to two digits after the decimal point.

            if (totalPrice <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice-money):f2}lv more.");
            }


        }
    }
}
