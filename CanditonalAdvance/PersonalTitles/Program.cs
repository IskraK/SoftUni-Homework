﻿using System;

namespace PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	"Mr." – мъж(пол 'm') на 16 или повече години
            //•	"Master" – момче(пол 'm') под 16 години
            //•	"Ms." – жена(пол 'f') на 16 или повече години
            //•	"Miss" – момиче(пол 'f') под 16 години
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            if (gender=="m")
            {
                if (age>=16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            }
            else if (gender=="f")
            {
                if (age>=16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
