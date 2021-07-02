using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new List<string>() 
            { 
                "Pesho", 
                "Gosho", 
                "123", 
                "456" 
            });

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
