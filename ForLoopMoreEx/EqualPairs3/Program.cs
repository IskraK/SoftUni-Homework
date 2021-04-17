using System;

namespace EqualPairs3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int prevSum = 0;
            int currSum = 0;
            int currDiff = 0;
            int maxDiff = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    currSum += int.Parse(Console.ReadLine());
                    currDiff = Math.Abs(prevSum - currSum);
                }
                if (currDiff != 0 && currDiff > maxDiff && currDiff != currSum)
                {
                    maxDiff = currDiff;
                }
                prevSum = currSum;
                currSum = 0;
            }
            if (currDiff == 0 || n == 1)
            {
                Console.WriteLine($"Yes, value={prevSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
