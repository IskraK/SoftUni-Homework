using System;

namespace CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред - минути разходка на ден - цяло число в интервала[1...50]
            //•	На втория ред - броят на разходките дневно - цяло число в интервала[1…10]
            //•	На третия ред - приетите от котката калории на ден – цяло число в интервала[100…4000]
            int minutesWalkingPerDay = int.Parse(Console.ReadLine());
            int numberWalkingPerDay = int.Parse(Console.ReadLine());
            int takenCaloriesPerDay = int.Parse(Console.ReadLine());
            //За всяка минута от разходката, котката гори по 5 калории.Разходката е достатъчна, ако котката изграря 50 % от приетите калории.
            //•	Ако изгорените калории през разходката са повече или равни на  50 % от приетите през деня калории: 
            //        "Yes, the walk for your cat is enough. Burned calories per day: {общо изгорени калории от разходката}."
            //•	Ако изгорените калории през разходката са по - малко от 50 % от приетите през деня калории:
            //        "No, the walk for your cat is not enough. Burned calories per day: {общо изгорени калории от разходката}."
            int burnedCaloties = numberWalkingPerDay * minutesWalkingPerDay * 5;
            double neededBurnedCalories = 0.5 * takenCaloriesPerDay;
            if (burnedCaloties >= neededBurnedCalories)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnedCaloties}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnedCaloties}.");
            }
        }
    }
}
