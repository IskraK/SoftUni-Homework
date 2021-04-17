using System;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxSum = int.MinValue;
            int minSum = int.MaxValue;
            int currSum = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    currSum += int.Parse(Console.ReadLine());
                }
                if (currSum >= maxSum)
                {
                    maxSum = currSum;
                }
                if (currSum <= minSum)
                {
                    minSum = currSum;
                }
                currSum = 0;
            }
            if (maxSum == minSum)
            {
                Console.WriteLine($"Yes, value={maxSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxSum - minSum}");
            }
        }
    }
}
