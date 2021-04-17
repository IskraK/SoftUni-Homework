using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int bestSize = 0;
            int bestIndex = 0;
            int bestSum = 0;
            int[] bestSequence = new int[size];
            int bestSample = 1;
            int sample = 0;

            while (true)
            {
                string line = Console.ReadLine();
                sample += 1;
                if (line == "Clone them!")
                {
                    break;
                }

                int[] sequence = line
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int sum = 0;

                foreach (var number in sequence)
                {
                    sum += number;
                }

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == 0)
                    {
                        continue;
                    }
                    int currSize = 1;

                    for (int j = i + 1; j < sequence.Length; j++)
                    {
                        if (sequence[i] == sequence[j])
                        {
                            currSize += 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currSize > bestSize)
                    {
                        bestSize = currSize;
                        bestIndex = i;
                        bestSum = sum;
                        bestSequence = sequence;
                        bestSample = sample;
                    }
                    else if (currSize == bestSize)
                    {
                        if (i < bestIndex)
                        {
                            bestSize = currSize;
                            bestIndex = i;
                            bestSum = sum;
                            bestSequence = sequence;
                            bestSample = sample;
                        }
                        else if (i == bestIndex && sum > bestSum)
                        {
                            bestSize = currSize;
                            bestIndex = i;
                            bestSum = sum;
                            bestSequence = sequence;
                            bestSample = sample;
                        }

                    }
                }

            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}
