using System;

namespace EqualPairs2
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairCount = int.Parse(Console.ReadLine());
            int pairOne = int.Parse(Console.ReadLine());
            pairOne += int.Parse(Console.ReadLine());
            int pairDiff = 0;
            for (int i = 1; i < pairCount; i++)
            {
                int pairTwo = int.Parse(Console.ReadLine());
                pairTwo += int.Parse(Console.ReadLine());
                if (pairOne != pairTwo && (Math.Abs(pairOne - pairTwo) > pairDiff))
                {
                    pairDiff = Math.Abs(pairOne - pairTwo);
                }
                pairOne = pairTwo;
            }
            if (pairDiff == 0)
            {
                Console.WriteLine($"Yes, value={pairOne}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={pairDiff}");
            }
        }
    }
}
