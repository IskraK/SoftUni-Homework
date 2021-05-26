using System;

namespace WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            //чете час от денонощието(цяло число) и ден от седмицата(текст) -въведени от потребителя и проверява дали офисът на фирма е отворен, като работното време на офисът е от 10 - 18 часа, от понеделник до събота включително
            int time = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            if (time>=10 && time<=18 && day != "Sunday")
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
