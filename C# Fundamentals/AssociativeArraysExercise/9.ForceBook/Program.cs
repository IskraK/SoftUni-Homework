using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> membersBySide = new Dictionary<string, List<string>>();
            Dictionary<string, string> members = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] parts = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = parts[0];
                    string forceUser = parts[1];
                    if (members.ContainsKey(forceUser))
                    {
                        continue;
                    }

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                        membersBySide.Add(forceSide, new List<string>());
                    }
                    membersBySide[forceSide].Add(forceUser);
                    members.Add(forceUser, forceSide);
                }
                else
                {
                    string[] parts = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = parts[0];
                    string forceSide = parts[1];

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                        membersBySide.Add(forceSide, new List<string>());
                    }

                    if (members.ContainsKey(forceUser))
                    {
                        string oldSide = members[forceUser];
                        membersBySide[oldSide].Remove(forceUser);
                        membersBySide[forceSide].Add(forceUser);
                        members[forceUser] = forceSide;
                    }
                    else
                    {
                        membersBySide[forceSide].Add(forceUser);
                        members.Add(forceUser, forceSide);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            Dictionary<string, List<string>> result =
                membersBySide
                .Where(s => s.Value.Count > 0)
                .OrderByDescending(s => s.Value.Count)
                .ThenBy(s => s.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                kvp.Value.Sort();

                foreach (var member in kvp.Value)
                {
                    Console.WriteLine($"! {member}");
                }
            }
            // 80/100 2tests TimeLimit
        }
    }
}
