﻿namespace _05.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(' ',MergeSort(arr.ToList())));
        }

        static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int middle = list.Count / 2;
            List<int> leftList = MergeSort(list.GetRange(0, middle));
            List<int> rightList = MergeSort(list.GetRange(middle, list.Count - middle));
            return MergeArray(leftList, rightList);
        }

        private static List<int> MergeArray(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            for (int i = leftIndex; i < left.Count; i++)
            {
                result.Add(left[i]);
            }

            for (int i = rightIndex; i < right.Count; i++)
            {
                result.Add(right[i]);
            }
            return result;
        }
    }
}