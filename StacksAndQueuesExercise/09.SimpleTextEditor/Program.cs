using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOperations = int.Parse(Console.ReadLine());
            Stack<string> text = new Stack<string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOperations; i++)
            {
                string[] input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "1":
                        string str = input[1];
                        sb.Append(str);
                        text.Push(sb.ToString());
                        break;
                    case "2":
                        int count = int.Parse(input[1]);
                        if (sb.Length >= count)
                        {
                            sb=sb.Remove(sb.Length - count, count);
                            text.Push(sb.ToString());
                        }
                        break;
                    case "3":
                        int index = int.Parse(input[1]);
                        Console.WriteLine(sb[index-1]);
                        break;
                    case "4":
                        if (text.Count > 0)
                        {
                            text.Pop();
                            if (text.Count > 0)
                            {
                                sb = new StringBuilder(text.Peek());
                            }
                            else
                            {
                                sb.Clear();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
