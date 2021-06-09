using System;

namespace _12.TriFunction2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> criteria = (s, n) =>
            {
                int sum = 0;
                foreach (var symbol in s)
                {
                    sum += symbol;
                }
                return sum >= n;
            };

            Func<string[], Func<string, int, bool>, string> func = (s, criteria) =>
            {
                foreach (var name in s)
                {
                    if (criteria(name, number))
                    {
                        return name;
                    }
                }
                return "";
            };

            Console.WriteLine(func(names, criteria));
        }
    }
}
