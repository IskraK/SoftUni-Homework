using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = PrintStringArray;
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            print(names);
        }

        private static void PrintStringArray(string[] arr)
        {
            //List<string> newArr = new List<string>();

            //foreach (var item in arr)
            //{
            //    newArr.Add("Sir " + item);
            //}

            //Console.WriteLine(string.Join(Environment.NewLine,newArr));

            StringBuilder sb = new StringBuilder();
            foreach (var name in arr)
            {
                sb.Append("Sir ");
                sb.AppendLine(name);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
