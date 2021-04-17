using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            const int water = 20;
            const int internet = 15;
            int months = int.Parse(Console.ReadLine());
            double othersTotal = 0;
            double electicityTotal = 0;
            //•	1ви ред: "Electricity: {ток за всички месеци} lv"
            //•	2ри ред: "Water: {вода за всички месеци} lv"
            //•	3ти ред: "Internet: {интернет за всички месеци} lv"
            //•	4ти ред: "Other: {други за всички месеци} lv"
            //•	5ти ред: "Average: {средно всички разходи за месец} lv"
            for (int i = 1; i <= months; i++)
            {
            double electricity = double.Parse(Console.ReadLine());
                electicityTotal += electricity;
            }
            othersTotal = (water * months + internet * months + electicityTotal) * 1.2;
            double average= (water * months + internet * months + electicityTotal) * 2.2/months;
            Console.WriteLine($"Electricity: {electicityTotal:f2} lv");
            Console.WriteLine($"Water: {water*months:f2} lv");
            Console.WriteLine($"Internet: {internet*months:f2} lv");
            Console.WriteLine($"Other: {othersTotal:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");
        }
    }
}
