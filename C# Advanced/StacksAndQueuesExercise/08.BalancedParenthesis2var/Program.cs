using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> opening = new Stack<char>();
            bool isBalanced = true;

            string input = Console.ReadLine();

            foreach (char item in input)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    opening.Push(item);
                }
                else
                {
                    //bool isValid1 = item == ')' && opening.Pop() == '(';
                    //bool isValid2 = item == ']' && opening.Pop() == '[';
                    //bool isValid3 = item == '}' && opening.Pop() == '{';

                    //if (!isValid1 && !isValid2 && !isValid3 && opening.Count > 0)
                    //{
                    //    isBalanced = false;
                    //    break;
                    //}
                    if (opening.Count != 0)
                    {
                        if (item == ')' && opening.Pop() != '(')
                        {
                            isBalanced = false;
                            break;
                        }
                        else if (item == ']' && opening.Pop() != '[')
                        {
                            isBalanced = false;
                            break;
                        }
                        else if (item == '}' && opening.Pop() != '{')
                        {
                            isBalanced = false;
                            break;
                        }
                    }

                }
            }

            if (isBalanced && opening.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            // 75/100
        }
    }
}
