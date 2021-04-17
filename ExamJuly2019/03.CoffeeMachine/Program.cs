using System;

namespace _03.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeDrink = Console.ReadLine();
            string typeSugar = Console.ReadLine();
            int numberDrinks = int.Parse(Console.ReadLine());
            //            Без захар           Нормално        Допълнително   захар
            //Еспресо     0.90 лв./ бр.    1 лв. / бр.        1.20 лв. / бр.
            //Капучино    1.00 лв. / бр.   1.20 лв. / бр.     1.60 лв. / бр.
            //Чай         0.50 лв. / бр.   0.60 лв. / бр.     0.70 лв. / бр.
            double totalPrice = 0;
            //•	Първи ред -напитка - текст с възможности"Espresso", "Cappuccino" или "Tea"
            //•	Втори ред -захар - текст  с възможности "Without", "Normal" или "Extra"
            //•	Трети ред -брой напитки - цяло число в интервала[1… 50]
            //•	При избрана напитка без захар има 35 % отстъпка.
            //•	При избрана напитка "Espresso" и закупени поне 5 броя, има 25 % отстъпка.
            //•	При сума надвишава 15 лева, 20 % отстъпка от крайната цена,  
            switch (typeDrink)
            {
                case "Espresso":
                    if (typeSugar == "Without")
                    {
                        totalPrice = numberDrinks * 0.90 * 0.65;
                    }
                    else if (typeSugar == "Normal")
                    {
                        totalPrice = numberDrinks * 1.0;
                    }
                    else if (typeSugar == "Extra")
                    {
                        totalPrice = numberDrinks * 1.2;
                    }
                    if (numberDrinks >= 5)
                    {
                        totalPrice *= 0.75;
                    }
                    break;
                case "Cappuccino":
                    if (typeSugar == "Without")
                    {
                        totalPrice = numberDrinks * 1.0 * 0.65;
                    }
                    else if (typeSugar == "Normal")
                    {
                        totalPrice = numberDrinks * 1.20;
                    }
                    else if (typeSugar == "Extra")
                    {
                        totalPrice = numberDrinks * 1.60;
                    }
                    break;
                case "Tea":
                    if (typeSugar == "Without")
                    {
                        totalPrice = numberDrinks * 0.50 * 0.65;
                    }
                    else if (typeSugar == "Normal")
                    {
                        totalPrice = numberDrinks * 0.60;
                    }
                    else if (typeSugar == "Extra")
                    {
                        totalPrice = numberDrinks * 0.70;
                    }
                    break;
            }
            if (totalPrice > 15)
            {
                totalPrice *= 0.8;
            }
            Console.WriteLine($"You bought {numberDrinks} cups of {typeDrink} for {totalPrice:f2} lv.");
        }
    }
}
