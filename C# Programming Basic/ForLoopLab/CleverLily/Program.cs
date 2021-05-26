using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Възрастта на Лили - цяло число в интервала[1...77]
            //•	Цената на пералнята – реално число
            //•	Цена на играчки – реално число
            int age = int.Parse(Console.ReadLine());
            double washMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            double totalMoney = 0;
            int numberToys = 0;
            double presentMoney = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    totalMoney += presentMoney;
                    presentMoney += 10;
                    totalMoney -= 1;
                }
                else
                {
                    numberToys += 1;
                }
            }
            totalMoney += numberToys * toysPrice;
            //•	Ако парите на Лили са достатъчни:
            //    o   “Yes! { N}” -където N е остатъка пари след покупката
            //•	Ако парите не са достатъчни:
            //    o   “No! { М}“ -където M е сумата, която не достига
            //•	Числата N и M трябва да за форматирани до вторият знак след десетичната запетая.
            double leftMoney = Math.Abs(totalMoney - washMachinePrice);
            if (totalMoney >= washMachinePrice) 
            {
                Console.WriteLine($"Yes! {leftMoney:f2}");
            }
            else
            {
                Console.WriteLine($"No! {leftMoney:f2}");
            }
        }
    }
}
