using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            string maxKeg="";
            double maxVolume = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                string typeOfKeg = Console.ReadLine();
                float radiusOfKeg = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double currVolume = Math.PI * Math.Pow(radiusOfKeg, 2) * height;

                if (currVolume >= maxVolume)
                {
                    maxVolume = currVolume;
                    maxKeg = typeOfKeg;
                }
            }
            Console.WriteLine(maxKeg);
        }
    }
}
