using System;

namespace Time15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            if (minute < 45)
            {
                minute += 15;
            }
            else
            {
                minute = minute+15-60;
                if (hour <= 22)
                {
                    hour += 1;
                }
                else
                {
                    hour = 0;
                }
            }
            Console.WriteLine($"{hour}:{minute:d2}");
        }
    }
}
