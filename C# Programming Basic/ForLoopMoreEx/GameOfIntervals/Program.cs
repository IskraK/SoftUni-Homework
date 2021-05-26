using System;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double result = 0;
            int countInterval1 = 0;
            int countInterval2 = 0;
            int countInterval3 = 0;
            int countInterval4 = 0;
            int countInterval5 = 0;
            int countInterval6 = 0;
            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                //•	От 0 до 9  20 % от числото
                //•	От 10 до 19  30 % от числото
                //•	От 20 до 29  40 % от числото
                //•	От 30 до 39  50 точки
                //•	От 40 до 50  100 точки
                //•	Невалидно число  резултата се дели на 2
                //Ако числото е отрицателно или по-голямо 50, тогава то е невалидно
                if (number >= 0 && number <=9)
                {
                    result += 0.20 * number;
                    countInterval1++;
                }
                else if (number >= 10 && number <= 19)
                {
                    result += 0.30 * number;
                    countInterval2++;
                }
                else if (number >= 20 && number <= 29)
                {
                    result += 0.40 * number;
                    countInterval3++;
                }
                else if (number >= 30 && number <= 39)
                {
                    result += 50;
                    countInterval4++;
                }
                else if (number >= 40 && number <= 50)
                {
                    result += 100;
                    countInterval5++;
                }
                else if (number < 0 || number > 50)
                {
                    result -= result/2;
                    countInterval6++;
                }
            }
            double pInterval1 = 1.0*countInterval1 / n * 100;
            double pInterval2 = 1.0*countInterval2 / n * 100;
            double pInterval3 = 1.0*countInterval3 / n * 100;
            double pInterval4 = 1.0*countInterval4 / n * 100;
            double pInterval5 = 1.0*countInterval5 / n * 100;
            double pInterval6 = 1.0*countInterval6 / n * 100;
            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {pInterval1:f2}%");
            Console.WriteLine($"From 10 to 19: {pInterval2:f2}%");
            Console.WriteLine($"From 20 to 29: {pInterval3:f2}%");
            Console.WriteLine($"From 30 to 39: {pInterval4:f2}%");
            Console.WriteLine($"From 40 to 50: {pInterval5:f2}%");
            Console.WriteLine($"Invalid numbers: {pInterval6:f2}%");
        }
    }
}
