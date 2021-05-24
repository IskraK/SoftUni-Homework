using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>(input);

            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
