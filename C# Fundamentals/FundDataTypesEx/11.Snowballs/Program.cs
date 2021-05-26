using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            //            You will receive N – an integer, the number of snowballs being made by Tony and Andi.
            //For each snowball you will receive 3 input lines:
            //•	On the first line you will get the snowballSnow – an integer.
            //•	On the second line you will get the snowballTime – an integer.
            //•	On the third line you will get the snowballQuality – an integer.
            //For each snowball you must calculate its snowballValue by the following formula:
            //(snowballSnow / snowballTime) ^ snowballQuality
            //At the end you must print the highest calculated snowballValue.

            int n = int.Parse(Console.ReadLine());

            BigInteger maxSnowballValue = 0;
            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValue > maxSnowballValue)
                {
                    maxSnowballValue = snowballValue;
                    result= $"{snowballSnow} : {snowballTime} = {maxSnowballValue} ({snowballQuality})";
                }
            }

            Console.WriteLine(result);
        }
    }
}
