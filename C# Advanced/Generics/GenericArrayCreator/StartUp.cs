using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] numbers = ArrayCreator.Create(4, 33);

            Console.WriteLine(string.Join(' ',strings));
            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}
