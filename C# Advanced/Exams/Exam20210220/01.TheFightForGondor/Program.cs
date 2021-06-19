using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWaves = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> platesDefense = new Queue<int>(platesInput);
            Stack<int> orcsPower = new Stack<int>();

            bool isFinish = false;

            for (int i = 1; i <= numberWaves; i++)
            {
                int[] orcsWave = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                foreach (var item in orcsWave)
                {
                    orcsPower.Push(item);
                }

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    platesDefense.Enqueue(extraPlate);
                }

                for (int j = 0; j < orcsWave.Length; j++)
                {
                    if (platesDefense.Count == 0 || orcsPower.Count == 0)
                    {
                        isFinish = true;
                        break;
                    }

                    if (platesDefense.Peek() > orcsPower.Peek())
                    {
                        int damagedPlate = platesDefense.Dequeue() - orcsPower.Pop();
                        platesDefense.Enqueue(damagedPlate);

                        for (int k = 0; k < platesDefense.Count - 1; k++)
                        {
                            platesDefense.Enqueue(platesDefense.Dequeue());
                        }
                    }
                    else if (platesDefense.Peek() < orcsPower.Peek())
                    {
                        int damagedPower = orcsPower.Pop() - platesDefense.Dequeue();
                        orcsPower.Push(damagedPower);
                    }
                    else
                    {
                        platesDefense.Dequeue();
                        orcsPower.Pop();
                    }
                }

                if (isFinish)
                {
                    break;
                }
            }

            if (orcsPower.Count == 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ",platesDefense)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ",orcsPower)}");
            }
        }
    }
}
