using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isBalanced = false;
            bool isOpenBracket = false;
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(" || input == ")")
                {
                    if (input  == "(")
                    {
                        isOpenBracket = true;
                    }
                    if (input == ")" && isOpenBracket)
                    {
                        isBalanced = true;
                        isOpenBracket = false;
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
