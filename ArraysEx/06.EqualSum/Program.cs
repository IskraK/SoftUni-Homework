using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isEqual = false;
            int index=0;

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = i+1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }
                for (int k = 0; k < i; k++)
                {
                    leftSum += arr[k];
                }

                if (leftSum==rightSum)
                {
                    isEqual = true;
                    index = i;
                }
            }

            if (isEqual)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
