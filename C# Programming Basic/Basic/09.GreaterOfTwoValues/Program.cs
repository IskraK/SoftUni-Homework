using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputType = Console.ReadLine();
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            string result="";

            switch (inputType)
            {
                case "int":
                    int num1 = int.Parse(input1);
                    int num2 = int.Parse(input2);
                    int intResult = GetMax(num1, num2);
                    Console.WriteLine(intResult);
                    break;
                case "char":
                    char char1 = char.Parse(input1);
                    char char2 = char.Parse(input2);
                     intResult = GetMax((int)char1, (int)char2);
                    Console.WriteLine((char)intResult);
                    break;
                case "string":
                    result = GetMax(input1, input2);
                    Console.WriteLine(result);

                    //int intString1 = 0;
                    //int intString2 = 0;

                    //for (int i = 0; i < input1.Length; i++)
                    //{
                    //    intString1 += (int)input1[i];
                    //}

                    //for (int i = 0; i < input2.Length; i++)
                    //{
                    //    intString2 += (int)input2[i];
                    //}

                    //intResult = GetMax(intString1, intString2);

                    //if (intResult == intString1)
                    //{
                    //    result = input1;
                    //}
                    //else
                    //{
                    //    result = input2;
                    //}

                    //Console.WriteLine(result);
                    break;
            }
        }

        private static int GetMax(int num1, int num2)
        {
            int result = 0;
            if (num1 > num2)
            {
                result = num1;
            }
            else
            {
                result = num2;
            }

            return result;
        }

        static string GetMax(string str1, string str2)
        {
            if (string.Compare(str1,str2) > 0)
            {
                return str1;
            }
            return str2;
        }
    }
}
