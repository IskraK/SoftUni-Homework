using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (arr.Length != 1)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i] + arr[i + 1];
                }

                //arr=arr.SkipLast(1).ToArray();
                arr = arr.Take(arr.Length - 1).ToArray();
            }
            Console.WriteLine(arr[0]);
        }
    }
}
