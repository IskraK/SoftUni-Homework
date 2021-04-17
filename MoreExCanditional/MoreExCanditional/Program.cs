using System;

namespace MoreExCanditional
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първият ред съдържа числото V – Обем на басейна в литри – цяло число в интервала[1…10000].
            //•	Вторият ред съдържа числото P1 – дебит на първата тръба за час – цяло число в интервала[1…5000].
            //•	Третият ред съдържа числото P2 – дебит на втората тръба за час– цяло число в интервала[1…5000].
            //•	Четвъртият ред съдържа числото H – часовете които работникът отсъства – реално число в интервала[1.0…24.00]
            int obemPool = int.Parse(Console.ReadLine());
            int debit1 = int.Parse(Console.ReadLine());
            int debit2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());
            //            •	До колко се е запълнил басейна и коя тръба с колко процента е допринесла.
            //o   "The pool is {запълненост на басейна в проценти}% full. Pipe 1: {процент вода от първата тръба}%. Pipe 2: {процент вода от втората тръба}%."
            //Aко басейнът се е препълнил – с колко литра е прелял за даденото време.
            //o   "For {часовете, които тръбите са пълнили вода} hours the pool overflows with {литрите вода в повече} liters."
            double pine1 = debit1 * hours;
            double pine2 = debit2 * hours;
            double pines = pine1 + pine2;
            double prinosP1 = pine1 / pines * 100;
            double prinosP2 = pine2 / pines * 100;
            double fullness = pines / obemPool * 100;
            if (pines<=obemPool)
            {
                Console.WriteLine($"The pool is {fullness:f2}% full. Pipe 1: {prinosP1:f2}%. Pipe 2: {prinosP2:f2}%.");
            }
            else
            {
                double moreWater = pines - obemPool;
                Console.WriteLine($"For {hours} hours the pool overflows with {moreWater:f2} liters.");
            }
        }
    }
}
