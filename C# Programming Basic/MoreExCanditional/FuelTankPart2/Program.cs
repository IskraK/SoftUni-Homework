using System;

namespace FuelTankPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Типа на горивото – текст с възможности: "Gas", "Gasoline" или "Diesel"
            //•	Количество гориво – реално число в интервала[1.00 … 50.00]
            //•	Притежание на клубна карта – текст с възможности: "Yes" или "No"
            string typeFuel = Console.ReadLine().ToLower();
            double fuelInTank = double.Parse(Console.ReadLine());
            string card = Console.ReadLine();
            //            •	Бензин – 2.22 лева за един литър,
            //            •	Дизел – 2.33 лева за един литър
            //            •	Газ – 0.93 лева за литър
            //Ако водача има карта за отстъпки,  той се възползва от следните намаления за литър гориво: 18 ст.за литър бензин, 12 ст.за литър дизел и 8 ст.за литър газ.
            //Ако шофьора е заредил между 20 и 25 литра включително, той получава 8 процента отстъпка от крайната цена, при повече от 25 литра гориво, той получава 10 процента отстъпка от крайната цена.
            const double gasolinePerLitre = 2.22;
            const double dieselPerLitre = 2.33;
            const double gasPerLitre = 0.93;
            double discountPriceGasoline = gasolinePerLitre - 0.18;
            double discountPriceDiesel = dieselPerLitre - 0.12;
            double discountPriceGas = gasPerLitre - 0.08;
            const double dicountOver25Litres = 0.9;
            const double dicount20To25Litres = 0.92;
            double discount = 0;
            double price = 0;
            if (fuelInTank>25)
            {
                discount = dicountOver25Litres;
                if (card == "Yes")
                {
                    if (typeFuel == "gasoline")
                    {
                        price = fuelInTank * discountPriceGasoline * discount;
                    }
                    else if (typeFuel == "diesel")
                    {
                        price = fuelInTank * discountPriceDiesel * discount;
                    }
                    else if (typeFuel == "gas")
                    {
                        price = fuelInTank * discountPriceGas * discount;
                    }
                }
                else if (card=="No")
                {
                    if (typeFuel == "gasoline")
                    {
                        price = fuelInTank *  gasolinePerLitre*discount;
                    }
                    else if (typeFuel == "diesel")
                    {
                        price = fuelInTank * dieselPerLitre*discount;
                    }
                    else if (typeFuel == "gas")
                    {
                        price = fuelInTank * gasPerLitre*discount;
                    }
                }
            }
            else if (fuelInTank>=20&&fuelInTank<=25)
            {
                discount = dicount20To25Litres;
                if (card == "Yes")
                {
                    if (typeFuel == "gasoline")
                    {
                        price = fuelInTank * discountPriceGasoline * discount;
                    }
                    else if (typeFuel == "diesel")
                    {
                        price = fuelInTank * discountPriceDiesel * discount;
                    }
                    else if (typeFuel == "gas")
                    {
                        price = fuelInTank * discountPriceGas * discount;
                    }
                }
                else if (card == "No")
                {
                    if (typeFuel == "gasoline")
                    {
                        price = fuelInTank * gasolinePerLitre*discount;
                    }
                    else if (typeFuel == "diesel")
                    {
                        price = fuelInTank * dieselPerLitre*discount;
                    }
                    else if (typeFuel == "gas")
                    {
                        price = fuelInTank * gasPerLitre*discount;
                    }
                }
            }
            else
            {
                if (card == "Yes")
                {
                    if (typeFuel == "gasoline")
                    {
                        price = fuelInTank * discountPriceGasoline;
                    }
                    else if (typeFuel == "diesel")
                    {
                        price = fuelInTank * discountPriceDiesel;
                    }
                    else if (typeFuel == "gas")
                    {
                        price = fuelInTank * discountPriceGas;
                    }
                }
                else if (card == "No")
                {
                    if (typeFuel == "gasoline")
                    {
                        price = fuelInTank * gasolinePerLitre;
                    }
                    else if (typeFuel == "diesel")
                    {
                        price = fuelInTank * dieselPerLitre;
                    }
                    else if (typeFuel == "gas")
                    {
                        price = fuelInTank * gasPerLitre;
                    }
                }
            }
            //            •	"{крайната цена на горивото} lv."
            //Цената на горивото да бъде форматираната до втората цифра след десетичния знак.
            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
