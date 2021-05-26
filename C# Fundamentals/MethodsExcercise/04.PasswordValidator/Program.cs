using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            PassswordCheck(password);

        }

        private static void PassswordCheck(string password)
        {
            bool isValid = true;
            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }


            isValid = true;
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if ((int)password[i] >= 32 && (int)password[i] <= 47
                    || (int)password[i] >= 58 && (int)password[i] <= 64
                    || (int)password[i] >= 91 && (int)password[i] <= 96
                    || (int)password[i] >= 123 && (int)password[i] <= 127)
                {
                    isValid = false;
                }

                if ((int)password[i] > 47 && (int)password[i] < 58)
                {
                    counter++;
                }

            }

            if (!isValid)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            
            if (counter < 2)
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
