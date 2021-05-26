using System;
using System.Linq;

namespace _04.ReverseArrayOfStringsvar2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine()
            //    .Split()
            //    .ToArray();

            //string[] oldInput = input;
            //for (int i = 0; i < input.Length / 2; i++)
            //{
            //    input[i] = input[input.Length - 1 - i];
            //    input[input.Length - 1 - i] = oldInput[i];
            //}

            //Console.WriteLine(string.Join(' ', input));
            //НЕ РАБОТИ ПРАВИЛНО. ПРОМЕНЯ И oldInput независимо дали е извън или вътре във FOR LOOP


            //var input = Console.ReadLine()
            //    .Split()
            //    .ToArray();

            //for (int i = 0; i < input.Length / 2; i++)
            //{
            //    var oldInput = input[i];
            //    input[i] = input[input.Length - 1 - i];
            //    input[input.Length - 1 - i] = oldInput;
            //}

            //Console.WriteLine(string.Join(' ', input));
            ////РАБОТИ ПРАВИЛНО. 


            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < input.Length / 2; i++)
            {
                string oldInput = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = oldInput;
            }

            Console.WriteLine(string.Join(' ', input));
            //РАБОТИ ПРАВИЛНО.
        }
    }
}
