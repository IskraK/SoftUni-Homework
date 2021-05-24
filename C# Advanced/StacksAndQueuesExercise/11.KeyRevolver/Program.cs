using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int pticeOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackOfBullets = new Stack<int>(bullets);
            Queue<int> queueOfLocks = new Queue<int>(locks);
            int count = 0;
            int usedBullets = 0;

            while (stackOfBullets.Count > 0 && queueOfLocks.Count > 0)
            {
                if (stackOfBullets.Peek() <= queueOfLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    stackOfBullets.Pop();
                    queueOfLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackOfBullets.Pop();
                }

                count++;

                if (count == sizeOfGunBarrel && stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }

                usedBullets++;
            }

            if (stackOfBullets.Count >= 0 && queueOfLocks.Count == 0)
            {
                int earnedMoney = valueOfIntelligence - usedBullets * pticeOfBullet;
                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${earnedMoney}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
            }
        }
    }
}
