using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> myStack = new CustomStack<int>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (IndexOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else
                {
                    int[] numbers = input
                        .Split(new char[] {' ',',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();
                    myStack.Push(numbers);
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in myStack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
