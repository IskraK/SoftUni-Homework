using System;

namespace _1.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string line = Console.ReadLine();

            while (line != "Done")
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "TakeOdd":
                        string oddChars = string.Empty;
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                oddChars += password[i];
                            }
                        }
                        password = oddChars;
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        //•	Cut { index} { length}
                        //o Gets the substring with the given length starting from the given index from the password and removes its first occurrence of it, then prints the password on the console.
                        int index = int.Parse(parts[1]);
                        int length = int.Parse(parts[2]);
                        string substr = password.Substring(index, length);
                        int idxSubstr = password.IndexOf(substr);
                        password = password.Remove(idxSubstr, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        //•	Substitute { substring} { substitute}
                        //o If the raw password contains the given substring, replaces all of its
                        //occurrences with the substitute text given and prints the result.
                        //o If it doesn’t, prints "Nothing to replace!"
                        string substring = parts[1];
                        string substitute = parts[2];
                        if (password.Contains(substring))
                        {
                            while (password.Contains(substring))
                            {
                                password = password.Replace(substring, substitute);
                            }
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
