using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> removed = new List<int>();

            while (numbers.Count != 0)
            {
                int idx = int.Parse(Console.ReadLine());
                int value = 0;
                if (idx < 0)
                {
                    value = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    removed.Add(value);
                }
                else if (idx > numbers.Count - 1)
                {
                    value = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(numbers[0]);
                    removed.Add(value);
                }
                else
                {
                    value = numbers[idx];
                    numbers.RemoveAt(idx);
                    removed.Add(value);
                }
                    numbers = GetIncreasedDecreasedElements(numbers, value);
            }

            Console.WriteLine(removed.Sum());

        }

        private static List<int> GetIncreasedDecreasedElements(List<int> numbers, int value)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= value)
                {
                    numbers[i] += value;
                }
                else
                {
                    numbers[i] -= value;
                }
            }

            return numbers;
        }
    }
}
