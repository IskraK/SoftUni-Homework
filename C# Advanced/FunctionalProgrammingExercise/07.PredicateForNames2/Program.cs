using System;
using System.Linq;

namespace _07.PredicateForNames2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = names =>
              {
                  Predicate<string> filter = n => n.Length <= length;

                  foreach (var name in names.Where(n => filter(n)))
                  {
                      Console.WriteLine(name);
                  }
              };

            printNames(names);
        }
    }
}
