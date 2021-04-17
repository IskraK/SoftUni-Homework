using System;

namespace _3.EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Плод - текст с възможности: "Watermelon", "Mango", "Pineapple" или "Raspberry"
            //2.Размерът на сета -текст с възможности: "small" или "big"
            //3.Брой на поръчаните сетове - цяло число в интервала[1 … 10000]
            string fruit = Console.ReadLine();
            string typeSet = Console.ReadLine();
            int numberSets = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            //                Диня            Манго               Ананас          Малина
            //2 броя(small)  56 лв./ бр.      36.66 лв./ бр.   42.10 лв./ бр.   20 лв./ бр.
            //5 броя(big)    28.70 лв./ бр.   19.60 лв./ бр.   24.80 лв./ бр.   15.20 лв./ бр.
            if (fruit == "Watermelon")
            {
                if (typeSet == "small")
                {
                    totalPrice = numberSets * 56*2;
                }
                else
                {
                    totalPrice=numberSets*28.70*5;
                }
            }
            else if (fruit == "Mango")
            {
                if (typeSet == "small")
                {
                    totalPrice = numberSets * 36.66*2;
                }
                else
                {
                    totalPrice = numberSets * 19.60*5;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (typeSet == "small")
                {
                    totalPrice = numberSets * 42.10*2;
                }
                else
                {
                    totalPrice = numberSets * 24.80*5;
                }
            }
            else if (fruit == "Raspberry")
            {
                if (typeSet == "small")
                {
                    totalPrice = numberSets * 20*2;
                }
                else
                {
                    totalPrice = numberSets * 15.20*5;
                }
            }
            //•	от 400 лв.до 1000 лв.включително има 15 % отстъпка
            //•	над 1000 лв.има 50 % отстъпка
            if (totalPrice >= 400 && totalPrice <= 1000)
            {
                totalPrice *= 0.85;
            }
            else if (totalPrice > 1000)
            {
                totalPrice *= 0.5;
            }
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
