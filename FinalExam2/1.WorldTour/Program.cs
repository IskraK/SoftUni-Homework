using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops= Console.ReadLine();
                
            string line = Console.ReadLine();

            while (line != "Travel")
            {
                string[] parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "Add Stop":
                        //•	Add Stop:{ index}:{ string} – insert the given string at that index only if the index is valid
                        int idx = int.Parse(parts[1]);
                        string str = parts[2];
                        if (idx >= 0 && idx < stops.Length)
                        {
                            stops=stops.Insert(idx, str);
                        }
                        else if (idx== stops.Length)
                        {
                            stops = string.Concat(stops, str);
                        }
                        Console.WriteLine(stops);
                        break;
                    case "Remove Stop":
                        //•	Remove Stop:{ start_index}:{ end_index} – remove the elements of the string from the starting index to the end index(inclusive) if both indices are valid
                        int startIdx = int.Parse(parts[1]);
                        int endIdx = int.Parse(parts[2]);
                        if (0 <= startIdx && startIdx <= endIdx && endIdx < stops.Length)
                        {
                            stops=stops.Remove(startIdx, endIdx - startIdx + 1);
                        }
                        Console.WriteLine(stops);
                        break;
                    case "Switch":
                        //•	Switch: { old_string}:{ new_string} – if the old string is in the initial string, replace it with the new one. (all occurrences)
                        string oldStr = parts[1];
                        string newStr = parts[2];
                        if (stops.Contains(oldStr))
                        {
                            stops=stops.Replace(oldStr, newStr);
                        }
                        Console.WriteLine(stops);
                        break;
                    default:
                        break;
                }
                line = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
