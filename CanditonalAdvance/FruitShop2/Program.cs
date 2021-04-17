using System;

namespace FruitShop2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            double totalPrice = 0;
            bool error = false;
            //плод banana  apple orange  grapefruit kiwi    pineapple grapes
            //цена  2.50    1.20    0.85    1.45    2.70    5.50       3.85
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    totalPrice = amount * 2.50;
                }
                else if (fruit == "apple")
                {
                    totalPrice = amount * 1.20;
                }
                else if (fruit == "orange")
                {
                    totalPrice = amount * 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    totalPrice = amount * 1.45;
                }
                else if (fruit == "kiwi")
                {
                    totalPrice = amount * 2.70;
                }
                else if (fruit == "pineapple")
                {
                    totalPrice = amount * 5.50;
                }
                else if (fruit == "grapes")
                {
                    totalPrice = amount * 3.85;
                }
                else
                {
                    error = true;
                }
            }
            //плод banana  apple orange  grapefruit kiwi    pineapple grapes
            //цена 2.70    1.25    0.90    1.60     3.00    5.60        4.20

            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    totalPrice = amount * 2.70;
                }
                else if (fruit == "apple")
                {
                    totalPrice = amount * 1.25;
                }
                else if (fruit == "orange")
                {
                    totalPrice = amount * 0.90;
                }
                else if (fruit == "grapefruit")
                {
                    totalPrice = amount * 1.60;
                }
                else if (fruit == "kiwi")
                {
                    totalPrice = amount * 3.00;
                }
                else if (fruit == "pineapple")
                {
                    totalPrice = amount * 5.60;
                }
                else if (fruit == "grapes")
                {
                    totalPrice = amount * 4.20;
                }
                else
                {
                    error=true;
                }
            }
            else
            {
                error = true;
            }
            if (error)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{totalPrice:f2}");
            }
        }
    }
}
