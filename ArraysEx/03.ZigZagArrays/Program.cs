using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr1=new int[n];
            int[] arr2=new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (i % 2 == 0)
                {
                    arr1[i] = arr[0];
                    arr2[i] = arr[1];
                }
                else
                {
                    arr1[i] = arr[1];
                    arr2[i] = arr[0];
                }
            }

            Console.WriteLine(string.Join(" ",arr1));
            Console.WriteLine(string.Join(" ",arr2));
        }
    }
}
