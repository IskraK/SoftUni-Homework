using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int FACEBOOK = 150;
            const int INSTAGRAM = 100;
            const int REDDIT = 50;
            int openedTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            for (int i = 0; i <= openedTabs; i++)
            {
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
                string browser = Console.ReadLine();
                if (browser=="Facebook")
                {
                    salary -= FACEBOOK;
                }
                else if (browser=="Instagram")
                {
                    salary -= INSTAGRAM;
                }
                else if (browser == "Reddit")
                {
                    salary -= REDDIT;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
