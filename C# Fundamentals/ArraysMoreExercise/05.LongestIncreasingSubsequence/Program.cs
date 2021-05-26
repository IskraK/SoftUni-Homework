using System;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxLength = 0;
            int[] maxIncSub = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    int currLength = 0;
                    int[] currIncSub = new int[arr.Length];
                    currIncSub[currLength] = arr[i];
                    if (arr[j] > currIncSub[currLength])
                    {
                        currLength++;
                        currIncSub[currLength] = arr[j];
                        for (int k = j + 1; k < arr.Length; k++)
                        {
                            if (arr[k] > currIncSub[currLength])
                            {
                                currLength++;
                                currIncSub[currLength] = arr[k];
                            }
                            else
                            {
                                if (currLength > maxLength)
                                {
                                    maxLength = currLength;
                                    maxIncSub = currIncSub;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            Console.WriteLine(string.Join(" ",maxIncSub));
            //Ne RABOTI!!!
        }
    }
}
