using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //чете от конзолата плод(banana / apple / orange / grapefruit / kiwi / pineapple / grapes), ден от седмицата(Monday / Tuesday / Wednesday / Thursday / Friday / Saturday / Sunday) и количество(реално число)
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            double totalPrice = 0;
            //плод banana  apple orange  grapefruit kiwi    pineapple grapes
            //цена  2.50    1.20    0.85    1.45    2.70    5.50       3.85
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        totalPrice = amount*2.50;
                    }
                    else if (fruit == "apple")
                    {
                        totalPrice = amount*1.20;
                    }
                    else if (fruit == "orange")
                    {
                        totalPrice = amount*0.85;
                    }
                    else if (fruit == "grapefruit")
                    {
                        totalPrice = amount*1.45;
                    }
                    else if (fruit == "kiwi")
                    {
                        totalPrice = amount*2.70;
                    }
                    else if (fruit == "pineapple")
                    {
                        totalPrice = amount*5.50;
                    }
                    else if (fruit == "grapes")
                    {
                        totalPrice = amount*3.85;
                    }
                    if (fruit == "banana" || fruit == "apple" || fruit == "orange" || fruit == "grapefruit" || fruit == "kiwi" || fruit == "pineapple" || fruit == "grapes")
                    {
                        Console.WriteLine($"{totalPrice:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    //плод banana  apple orange  grapefruit kiwi    pineapple grapes
                    //цена 2.70    1.25    0.90    1.60    3.00      5.60    4.20
                    if (fruit == "banana")
                    {
                        totalPrice = amount*2.70;
                    }
                    else if (fruit == "apple")
                    {
                        totalPrice = amount*1.25;
                    }
                    else if (fruit == "orange")
                    {
                        totalPrice = amount*0.90;
                    }
                    else if (fruit == "grapefruit")
                    {
                        totalPrice = amount*1.60;
                    }
                    else if (fruit == "kiwi")
                    {
                        totalPrice = amount*3.00;
                    }
                    else if (fruit == "pineapple")
                    {
                        totalPrice = amount*5.60;
                    }
                    else if (fruit == "grapes")
                    {
                        totalPrice = amount*4.20;
                    }
                    if (fruit == "banana" || fruit == "apple" || fruit == "orange" || fruit == "grapefruit" || fruit == "kiwi" || fruit == "pineapple" || fruit == "grapes")
                    {
                        Console.WriteLine($"{totalPrice:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
