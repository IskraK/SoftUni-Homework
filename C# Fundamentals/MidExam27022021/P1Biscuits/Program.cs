using System;

namespace P1Biscuits
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerDayForWorker = int.Parse(Console.ReadLine());
            int countWorkers=int.Parse(Console.ReadLine());
            int biscuitsAnotherFactory = int.Parse(Console.ReadLine());

            int biscuitsForMonth = (int)Math.Floor(biscuitsPerDayForWorker * countWorkers * 20 + biscuitsPerDayForWorker * countWorkers * 10 * 0.75);

            double percentage = ((biscuitsForMonth - biscuitsAnotherFactory) / 1.0*biscuitsAnotherFactory )* 100;

            Console.WriteLine($"You have produced {biscuitsForMonth} biscuits for the past month.");

            if (biscuitsForMonth > biscuitsAnotherFactory)
            {
                Console.WriteLine($"You have produced {percentage:F2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You have produced {Math.Abs(percentage):F2} percent less biscuits.");
            }
        }
    }
}
