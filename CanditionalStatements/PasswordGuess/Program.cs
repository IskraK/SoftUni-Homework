using System;

namespace PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = "s3cr3t!P@ssw0rd";
            string passEnter = Console.ReadLine();
            if (pass == passEnter)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
