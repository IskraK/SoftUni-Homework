using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SetCover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            //int[][] sets = new[]
            //{
            //    new[] { 20 },
            //    new[] { 1, 5, 20, 30 },
            //    new[] { 3, 7, 20, 30, 40 },
            //    new[] { 9, 30 },
            //    new[] { 11, 20, 30, 40 },
            //    new[] { 3, 7, 40 }
            //};

            int[] universe = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberOfSets = int.Parse(Console.ReadLine());
            int[][] sets = new int[numberOfSets][];
            for (int i = 0; i < numberOfSets; i++)
            {
                sets[i] = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (int[] set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                int[] current = sets
                    .OrderByDescending(s => s.Count(universe.Contains))
                    .FirstOrDefault();

                selectedSets.Add(current);
                sets.Remove(current);

                foreach (var item in current)
                {
                    universe.Remove(item);
                }
            }

            return selectedSets;
        }
    }
}