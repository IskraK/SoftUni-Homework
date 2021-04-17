using System;
using System.Text.RegularExpressions;

namespace _2.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	Is surrounded with a "@" followed by one or more "#"
            //•	Is at least 6  characters long(without the surrounding "@" or "#")
            //•	Starts with a capital letter
            //•	Contains only letters(lower and upper case) and digits
            //•	Ends with a capital letter
            string pattern = @"(@[#]+)([A-Z][A-Za-z0-9]{4,}[A-Z])(@[#]+)";
            Regex regex = new Regex(pattern);
            int countOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBarcodes; i++)
            {
                string barcode = Console.ReadLine();
                var match = regex.Match(barcode);
                string product = match.Groups[2].Value;

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string productGroup = string.Empty;
                bool hasDigits = false;

                for (int j = 0; j < product.Length; j++)
                {
                    if (char.IsDigit(product[j]))
                    {
                        productGroup += product[j];
                        hasDigits = true;
                    }
                }

                if (hasDigits == false)
                {
                    productGroup = "00";
                }

                Console.WriteLine($"Product group: {productGroup}");
            }
        }
    }
}
