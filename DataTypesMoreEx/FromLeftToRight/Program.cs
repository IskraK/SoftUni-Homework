using System;
using System.Numerics;

namespace FromLeftToRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string left = "";
                string right = "";
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] != ' ' )
                    {
                        left += input[j];
                    }
                    if (input[j] == ' ' )
                    {
                        for (int k = j+1; k < input.Length; k++)
                        {
                        right += input[k];
                        }
                        break;
                    }
                }

                long leftNum = long.Parse(left);
                long rightNum = long.Parse(right);
                long sumDigits = 0;
                long maxNum = 0;

                    if (leftNum > rightNum)
                    {
                        maxNum = leftNum;
                    }
                    else
                    {
                        maxNum = rightNum;
                    }
                maxNum = Math.Abs(maxNum);
                while (maxNum > 0)
                {
                    sumDigits += maxNum % 10;
                    maxNum = maxNum/10;
                }
                Console.WriteLine(sumDigits);
            }
        }
    }
}
