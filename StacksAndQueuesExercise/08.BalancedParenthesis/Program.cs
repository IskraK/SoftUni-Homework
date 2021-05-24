using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            const string openinng = "([{";
            const string closing = ")]}";
            bool isBalanced = true;

            string input = Console.ReadLine();

            Stack<char> parenthesis = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (openinng.Contains(input[i]))
                {
                    parenthesis.Push(input[i]);
                }
                else
                {
                    if (parenthesis.Count > 0 && closing.IndexOf(input[i]) == openinng.IndexOf(parenthesis.Peek()))
                    {
                        parenthesis.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced && parenthesis.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
