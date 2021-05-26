using System;

namespace OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първият ред съдържа час на изпита – цяло число от 0 до 23.
            //•	Вторият ред съдържа минута на изпита – цяло число от 0 до 59.
            //•	Третият ред съдържа час на пристигане – цяло число от 0 до 23.
            //•	Четвъртият ред съдържа минута на пристигане – цяло число от 0 до 59.
            int hourOfExam = int.Parse(Console.ReadLine());
            int minuteOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minuteOfArrival = int.Parse(Console.ReadLine());
            //    •	“Late”, ако студентът пристига по-късно от часа на изпита.
            //    •	“On time”, ако студентът пристига точно в часа на изпита или до 30 минути по-рано.
            //    •	“Early”, ако студентът пристига повече от 30 минути преди часа на изпита.
            //Ако студентът пристига с поне минута разлика от часа на изпита, отпечатайте на следващия ред:
            //•	“mm minutes before the start” за идване по - рано с по-малко от час.
            //•	“hh: mm hours before the start” за подраняване с 1 час или повече.Минутите винаги печатайте с 2 цифри, например “1:05”.
            //•	 “mm minutes after the start” за закъснение под час.
            //•	“hh: mm hours after the start” за закъснение от 1 час или повече.Минутите винаги печатайте с 2 цифри, например “1:03”.
            int mmExam = hourOfExam * 60 + minuteOfExam;
            int mmArrival = hourOfArrival * 60 + minuteOfArrival;
            int mmDelta = mmExam - mmArrival;
            int hh = Math.Abs(mmDelta) / 60;
            int mm = Math.Abs(mmDelta) % 60;
            if (mmDelta<0 && mmDelta>-60)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{mm} minutes after the start");
            }
            else if (mmDelta <= -60)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{hh}:{mm:d2} hours after the start");
            }
            else if (mmDelta >= 0 && mmDelta <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{mm} minutes before the start");
            }
            else if (mmDelta>30 && mmDelta<60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{mm} minutes before the start");
            }
            else if (mmDelta >= 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{hh}:{mm:d2} hours before the start");
            }
        }
    }
}
