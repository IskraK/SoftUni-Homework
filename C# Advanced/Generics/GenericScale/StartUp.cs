using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<int>(3, 3);
            Console.WriteLine(scale.AreEqual());

            var scale1 = new EqualityScale<string>("Pesho", "Pesho");
            Console.WriteLine(scale1.AreEqual());

            var scale3 = new EqualityScale<string>("Pesho", "Gosho");
            Console.WriteLine(scale3.AreEqual());

            var scale4 = new EqualityScale<string>("Pesho", "pesho");
            Console.WriteLine(scale4.AreEqual());

            var scale5 = new EqualityScale<string>("Pesho", "3");
            Console.WriteLine(scale5.AreEqual());
        }
    }
}
