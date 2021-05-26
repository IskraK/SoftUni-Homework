using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string input = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int number = int.Parse(input);
                    int intResult = GetManipulation(dataType, number);
                    Console.WriteLine(intResult);
                    break;
                case "real":
                    double num = double.Parse(input);
                    double doubleResult = GetManipulation(dataType, num);
                    Console.WriteLine($"{doubleResult:f2}");
                    break;
                case "string":
                    string stringResult = GetManipulation(dataType, input);
                    Console.WriteLine(stringResult);
                    break;
                default:
                    break;
            }

        }

        private static int GetManipulation(string dataType, int number)
        {
            return number * 2;
        }

        private static double GetManipulation(string dataType, double number)
        {
            return number * 1.5;
        }

        private static string GetManipulation(string dataType, string input)
        {
            return $"${input}$";
        }
    }
}
