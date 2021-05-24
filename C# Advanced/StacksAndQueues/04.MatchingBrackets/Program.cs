using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol =='(')
                {
                    stack.Push(i);
                }
                else if (symbol == ')')
                {
                    int indexOpeningBracket = stack.Pop();
                    string result = input.Substring(indexOpeningBracket, i - indexOpeningBracket + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
