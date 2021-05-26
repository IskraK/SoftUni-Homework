using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sale = double.Parse(Console.ReadLine());
            double commission = 0;
            bool error = false;
            //Град    0 ≤ s ≤ 500       500 < s ≤ 1 000         1 000 < s ≤ 10 000      s > 10 000
            //Sofia       5 %                   7 %                 8 %             12 %
            //Varna       4.5 %                 7.5 %               10 %            13 %
            //Plovdiv     5.5 %                 8 %                 12 %            14.5 %
            switch (town)
            {
                case "Sofia":
                    if (sale>=0 && sale<=500)
                    {
                        commission = sale * 0.05;
                    }
                    else if (sale>500 && sale <=1000)
                    {
                        commission = sale * 0.07;
                    }
                    else if (sale >1000 && sale<=10000)
                    {
                        commission = sale * 0.08;
                    }
                    else if(sale>10000)
                    {
                        commission = sale * 0.12;
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                case "Varna":
                    if (sale >= 0 && sale <= 500)
                    {
                        commission = sale * 0.045;
                    }
                    else if (sale > 500 && sale <= 1000)
                    {
                        commission = sale * 0.075;
                    }
                    else if (sale > 1000 && sale <= 10000)
                    {
                        commission = sale * 0.1;
                    }
                    else if (sale > 10000)
                    {
                        commission = sale * 0.13;
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                case "Plovdiv":
                    if (sale >= 0 && sale <= 500)
                    {
                        commission = sale * 0.055;
                    }
                    else if (sale > 500 && sale <= 1000)
                    {
                        commission = sale * 0.08;
                    }
                    else if (sale > 1000 && sale <= 10000)
                    {
                        commission = sale * 0.12;
                    }
                    else if (sale > 10000)
                    {
                        commission = sale * 0.145;
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                default:
                    error = true;
                    break;
            }
            if (error)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{commission:f2}");
            }

        }
    }
}
