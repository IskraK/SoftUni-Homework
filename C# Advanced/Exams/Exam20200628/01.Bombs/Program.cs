using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DaturaBomb = 40;
            const int CherryBomb = 60;
            const int SmokeDecoyBomb = 120;

            int[] effectInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] casingInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffect = new Queue<int>(effectInput);
            Stack<int> bombCasing = new Stack<int>(casingInput);

            int daturaBombCount = 0;
            int cherryBombCount = 0;
            int smokeDecoyBombCount = 0;

            while (true)
            {
                if (bombEffect.Count == 0 || bombCasing.Count == 0)
                {
                    break;
                }

                if (daturaBombCount >= 3 && cherryBombCount >= 3 && smokeDecoyBombCount >= 3)
                {
                    break;
                }

                if (bombEffect.Peek() + bombCasing.Peek() == DaturaBomb)
                {
                    daturaBombCount++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (bombEffect.Peek() + bombCasing.Peek() == CherryBomb)
                {
                    cherryBombCount++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (bombEffect.Peek() + bombCasing.Peek() == SmokeDecoyBomb)
                {
                    smokeDecoyBombCount++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else
                {
                    bombCasing.Push(bombCasing.Pop() - 5);
                }
            }

            if (daturaBombCount >= 3 && cherryBombCount >= 3 && smokeDecoyBombCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffect)}");
            }

            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ",bombCasing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombCount}");
        }
    }
}
