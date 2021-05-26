using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string mathOperation = Console.ReadLine();
            //Да се отпечата на конзолата един ред:
            //•	Ако операцията е събиране, изваждане или умножение:
            //    o    "{N1} {оператор} {N2} = {резултат} – {even/odd}"
            //•	Ако операцията е деление:
            //    o   "{N1} / {N2} = {резултат}" – резултатът е форматиран до вторият знак след дес.запетая
            //•	Ако операцията е модулно деление:
            //     o   "{N1} % {N2} = {остатък}"
            //•	В случай на деление с 0(нула): 
            //    o   "Cannot divide {N1} by zero"
            double result = 0;
            if (mathOperation=="+")
            {
                result = N1 + N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result} - odd");
                }
            }
            else if (mathOperation=="-")
            {
                result = N1 - N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result} - odd");
                }
            }
            else if (mathOperation == "*")
            {
                result = N1 * N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result} - odd");
                }
            }
            else if (mathOperation == "/")
            {
                if (N2!=0)
                {
                    result = N1 / N2;
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
            else if (mathOperation == "%")
            {
                if (N2 != 0)
                {
                    result = N1 % N2;
                    Console.WriteLine($"{N1} {mathOperation} {N2} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
        }
    }
}
