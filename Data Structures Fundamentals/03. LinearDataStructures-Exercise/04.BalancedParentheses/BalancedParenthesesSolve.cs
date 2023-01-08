namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> result = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                char current = parentheses[i];

                if (current == '(' || current == '{' || current == '[')
                {
                    result.Push(current);
                }
                else
                {

                    if (result.Count == 0 && i < parentheses.Length)
                    {
                        return false;
                    }

                    if (result.Peek() == '(' && current == ')')
                    {
                        result.Pop();
                    }
                    else if (result.Peek() == '{' && current == '}')
                    {
                        result.Pop();
                    }
                    else if (result.Peek() == '[' && current == ']')
                    {
                        result.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;


            ////2-nd decision
            //const string openinng = "([{";
            //const string closing = ")]}";
            //bool isBalanced = true;

            //Stack<char> result = new Stack<char>();

            //for (int i = 0; i < parentheses.Length; i++)
            //{
            //    if (openinng.Contains(parentheses[i]))
            //    {
            //        result.Push(parentheses[i]);
            //    }
            //    else
            //    {
            //        if (result.Count > 0 && closing.IndexOf(parentheses[i]) == openinng.IndexOf(result.Peek()))
            //        {
            //            result.Pop();
            //        }
            //        else
            //        {
            //            isBalanced = false;
            //            break;
            //        }
            //    }
            //}

            //if (isBalanced && result.Count == 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            ////3-rd decision
            //Stack<char> parenthesStack = new Stack<char>();
            //foreach (var symbol in parentheses)
            //{
            //    if (parenthesStack.Any())
            //    {
            //        char check = parenthesStack.Peek();
            //        if (check == '{' && symbol == '}')
            //        {
            //            parenthesStack.Pop();
            //            continue;
            //        }
            //        else if (check == '[' && symbol == ']')
            //        {
            //            parenthesStack.Pop();
            //            continue;
            //        }
            //        else if (check == '(' && symbol == ')')
            //        {
            //            parenthesStack.Pop();
            //            continue;
            //        }
            //    }

            //    parenthesStack.Push(symbol);
            //}

            //return !parenthesStack.Any();


            ////4-th decision
            //Stack<char> elements = new Stack<char>();
            //bool isBalanced = true;

            //if (parentheses != null)
            //    foreach (var item in parentheses)
            //    {
            //        switch (item)
            //        {
            //            case '(':
            //            case '[':
            //            case '{':
            //                elements.Push(item);
            //                break;
            //            case ')':
            //                if (!elements.Any() || elements.Pop() != '(')
            //                {
            //                    isBalanced = false;
            //                }
            //                break;
            //            case ']':
            //                if (!elements.Any() || elements.Pop() != '[')
            //                {
            //                    isBalanced = false;
            //                }
            //                break;
            //            case '}':
            //                if (!elements.Any() || elements.Pop() != '{')
            //                {
            //                    isBalanced = false;
            //                }
            //                break;
            //        }
            //    }

            //return isBalanced;
        }
    }
}
