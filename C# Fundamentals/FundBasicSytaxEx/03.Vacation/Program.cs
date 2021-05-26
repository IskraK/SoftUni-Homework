using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Friday Saturday    Sunday
            //Students    8.45    9.80        10.46
            //Business    10.90   15.60       16
            //Regular      15      20        22.50
            int countOfGroup = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = 0;
            if (typeOfGroup== "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 10.46;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 22.50;
                }
            }

            double totalPrice = price*countOfGroup;
            //            •	Students – if the group is bigger than or equal to 30 people you should reduce the total price by 15 %
            //•	Business – if the group is bigger than or equal to  100 people 10 of them can stay for free.
            //•	Regular – if the group is bigger than or equal to 10 and less than or equal to 20 reduce the total price by 5 %
            if ((typeOfGroup == "Students") && (countOfGroup >= 30))
            {
                totalPrice *= 0.85;
            }
            else if ((typeOfGroup == "Business") && (countOfGroup >= 100))
            {
                totalPrice -= price * 10;
            }
            else if ((typeOfGroup == "Regular") && (countOfGroup >= 10) && (countOfGroup <= 20))
            {
                totalPrice *= 0.95;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
