﻿using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int num = 1; num <= n; num++)
            {
                int sum = 0;
                int digits = num;
                while (digits > 0)
                {
                    sum += digits % 10;
                    digits = digits / 10;
                }
                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", num, isSpecial);
            }

        }
    }
}
