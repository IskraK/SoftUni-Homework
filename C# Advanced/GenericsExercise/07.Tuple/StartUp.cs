using System;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> tuple1 = new Tuple<string, string>($"{firstLine[0]} {firstLine[1]}", firstLine[2]);
            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2}");

            string[] secondLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, int> tuple2 = new Tuple<string, int>(secondLine[0], int.Parse(secondLine[1]));
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");

            string[] thirdLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2}");
        }
    }
}
