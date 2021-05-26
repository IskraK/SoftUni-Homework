using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            const int microbusPricePerTon = 200;
            const int truckPricePerTon = 175;
            const int trainPricePerTon = 120;
            int numberLoads = int.Parse(Console.ReadLine());
            int loadSum = 0;
            double totalPrice = 0;
            double averagePrice = 0;
            double loadMicrobus = 0;
            double loadTruck = 0;
            double loadTrain = 0;
            for (int i = 0; i < numberLoads; i++)
            {
                int load = int.Parse(Console.ReadLine());
                loadSum += load;
                //•	До 3 тона – микробус(200 лева на тон)
                //•	От 4 до 11 тона – камион(175 лева на тон)
                //•	12 и повече тона – влак(120 лева на тон)
                if (load <= 3)
                {
                    loadMicrobus += load;
                }
                else if (load >= 4 && load <= 11)
                {
                    loadTruck += load;
                }
                else if (load >= 12)
                {
                    loadTrain += load;
                }
            }
            totalPrice = loadMicrobus * microbusPricePerTon + loadTruck * truckPricePerTon + loadTrain * trainPricePerTon;
            averagePrice = totalPrice / loadSum;
            double pLoadMicrobus = loadMicrobus / loadSum * 100;
            double pLoadTruck = loadTruck / loadSum * 100;
            double pLoadTrain = loadTrain / loadSum * 100;
            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{pLoadMicrobus:f2}%");
            Console.WriteLine($"{pLoadTruck:f2}%");
            Console.WriteLine($"{pLoadTrain:f2}%");
        }
    }
}
