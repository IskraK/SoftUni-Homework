using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLilies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputRoses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(inputLilies);
            Queue<int> roses = new Queue<int>(inputRoses);
            int countOfWreaths = 0;
            int countOfFlowers = 0;

            while (true)
            {
                if (lilies.Count == 0 || roses.Count == 0)
                {
                    break;
                }

                if (lilies.Peek() + roses.Peek() == 15)
                {
                    countOfWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() < 15)
                {
                    countOfFlowers += lilies.Pop() + roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    int liliesCount = lilies.Peek() - 2;

                    if (liliesCount + roses.Peek() < 15)
                    {
                        countOfFlowers += lilies.Pop() + roses.Dequeue();
                    }
                    else if (liliesCount + roses.Peek() == 15)
                    {
                        countOfWreaths++;
                        lilies.Pop();
                        roses.Dequeue();
                    }
                    else
                    {
                        liliesCount -= 2;
                        lilies.Pop();
                        lilies.Push(liliesCount);
                    }
                }
            }

            countOfWreaths += countOfFlowers / 15;

            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
        }
    }
}
