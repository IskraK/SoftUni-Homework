using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Роза Далия   Лале Нарцис  Гладиола
            // 5   3.80    2.80    3       2.50
            //•	Вид цветя -текст с възможности -"Roses", "Dahlias", "Tulips", "Narcissus", "Gladiolus"
            //•	Брой цветя -цяло число в интервала[10…1000]
            //•	Бюджет - цяло число в интервала[50…2500]
            const double rosesPrice = 5;
            const double dahliasPrice = 3.80;
            const double tulipsPrice = 2.80;
            const double narcissusPrice = 3;
            const double gladiolusPrice = 2.50;
            string typeOfFlowers = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double totalSum = 0;
            //•	Ако Нели купи повече от 80 Рози - 10 % отстъпка от крайната цена
            //•	Ако Нели купи повече от 90  Далии - 15 % отстъпка от крайната цена
            //•	Ако Нели купи повече от 80 Лалета - 15 % отстъпка от крайната цена
            //•	Ако Нели купи по-малко от 120 Нарциса - цената се оскъпява с 15 %
            //•	Ако Нели Купи по-малко от 80 Гладиоли - цената се оскъпява с 20 %
            switch (typeOfFlowers)
            {
                case "Roses":
                    totalSum = numberOfFlowers * rosesPrice;
                    if (numberOfFlowers>80)
                    {
                        totalSum *=  0.9;
                    }
                    break;
                case "Dahlias":
                    totalSum = numberOfFlowers * dahliasPrice;
                    if (numberOfFlowers>90)
                    {
                        totalSum *= 0.85;
                    }
                    break;
                case "Tulips":
                    totalSum = numberOfFlowers * tulipsPrice;
                    if (numberOfFlowers>80)
                    {
                        totalSum *= 0.85;
                    }
                    break;
                case "Narcissus":
                    totalSum = numberOfFlowers * narcissusPrice;
                    if (numberOfFlowers<120)
                    {
                        totalSum *= 1.15;
                    }
                    break;
                case "Gladiolus":
                    totalSum = numberOfFlowers * gladiolusPrice;
                    if (numberOfFlowers<80)
                    {
                        totalSum *= 1.20;
                    }
                    break;
            }
            //•	Ако бюджета им е достатъчен - "Hey, you have a great garden with {броя цвета} {вид цветя} and {останалата сума} leva left."
            //•	Ако бюджета им е НЕ достатъчен -"Not enough money, you need {нужната сума} leva more."
            double moneyLeft = Math.Abs(budget - totalSum);
            if (budget>=totalSum)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {moneyLeft:f2} leva more.");
            }
        }
    }
}
