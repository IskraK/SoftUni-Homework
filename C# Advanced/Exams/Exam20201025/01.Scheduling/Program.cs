using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] threadInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int taskToBeKilled = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksInput);
            Queue<int> threads = new Queue<int>(threadInput);

            while (true)
            {
                if (tasks.Peek() == taskToBeKilled)
                {
                    break;
                }

                if (threads.Peek() >= tasks.Peek())
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(' ',threads));
        }
    }
}
