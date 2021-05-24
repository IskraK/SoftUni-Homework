using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses4var
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> elements = new Stack<char>();
            bool balanced = true;

            if (input != null)
                foreach (var item in input)
                {
                    switch (item)
                    {
                        case '(':
                            elements.Push(item);
                            break;
                        case '[':
                            elements.Push(item);
                            break;
                        case '{':
                            elements.Push(item);
                            break;
                        case ')':
                            if (!elements.Any() || elements.Pop() != '(')
                            {
                                balanced = false;
                            }
                            break;
                        case ']':
                            if (!elements.Any() || elements.Pop() != '[')
                            {
                                balanced = false;
                            }
                            break;
                        case '}':
                            if (!elements.Any() || elements.Pop() != '{')
                            {
                                balanced = false;
                            }
                            break;
                    }
                }

            Console.WriteLine(balanced ? "YES" : "NO");
        }
    }
}
