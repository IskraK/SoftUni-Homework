using System;
using System.Linq;

namespace Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = firstLine[0];
            string secondName = firstLine[1];
            string address = firstLine[2];
            string town = firstLine[3];
            if (firstLine.Length == 5)
            {
                town = firstLine[3] + ' ' + firstLine[4];
            }
            //string town= string.Join(' ', firstLine.TakeLast(firstLine.Length - 3));

            Threeuple<string, string,string> tuple1 = new Threeuple<string, string, string>($"{firstName} {secondName}", address,town);
            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2} -> {tuple1.Item3}");

            string[] secondLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //{ name} { liters of beer} { drunk or not}
            string name = secondLine[0];
            int beer = int.Parse(secondLine[1]);
            bool isDrunk = false;
            if (secondLine[2] == "drunk")
            {
                isDrunk = true;
            }
            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(name, beer, isDrunk);
            //Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(name, beer, secondLine[2] == "drunk");

            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2} -> {tuple2.Item3}");

            string[] thirdLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //{ name} { account balance} { bank name}
            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2} -> {tuple3.Item3}");
        }
    }
}
