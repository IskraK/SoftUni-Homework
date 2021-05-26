using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Първи ред: число за преобразуване - реално число
            //•	Втори ред: входна мерна единица - текст
            //•	Трети ред: изходна мерна единица(за резултата) - текст
            double number = double.Parse(Console.ReadLine());
            string inputValue = Console.ReadLine();
            string outputValue = Console.ReadLine();
            if (inputValue == "mm" && outputValue == "m")
            {
                number = number / 1000;
            }
            else if (inputValue == "m" && outputValue == "mm")
            {
                number = number * 1000;
            }
            else if (inputValue == "cm" && outputValue == "m")
            {
                number /= 100;
            }
            else if(inputValue=="m"&& outputValue=="cm")
            {
                number *= 100;
            }
            else if (inputValue == "mm" && outputValue == "cm")
            {
                number /= 10;
            }
            else if (inputValue=="cm"&& outputValue=="mm")
            {
                number *= 10;
            }
            Console.WriteLine($"{number:f3}");
        }
    }
}
