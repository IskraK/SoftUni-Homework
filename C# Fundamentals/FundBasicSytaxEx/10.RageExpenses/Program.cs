using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            //            •	On the first input line - lost games count – integer in the range[0, 1000].
            //•	On the second line – headset price -floating point number in range[0, 1000].
            //•	On the third line – mouse price -floating point number in range[0, 1000].
            //•	On the fourth line – keyboard price -floating point number in range[0, 1000].
            //•	On the fifth line – display price -floating point number in range[0, 1000].

            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            //            Every second lost game, Pesho trashes his headset.
            //Every third lost game, Pesho trashes his mouse.
            //When Pesho trashes both his mouse and headset in the same lost game, he also trashes his keyboard.
            //Every second time, when he trashes his keyboard, he also trashes his display.

            int numberHeadsets = lostGames / 2;
            int numberMouse = lostGames / 3;
            int numberKeyboards = lostGames / 6;
            int numberDisplays = lostGames / 12;
            double totalPrice = headsetPrice*numberHeadsets+mousePrice*numberMouse+keyboardPrice*numberKeyboards+displayPrice*numberDisplays;

            Console.WriteLine($"Rage expenses: {totalPrice:f2} lv.");
        }
    }
}
