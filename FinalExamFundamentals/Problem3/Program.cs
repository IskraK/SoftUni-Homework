using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> users = new Dictionary<string, int[]>();

            int capacity = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();

            while (line != "Statistics")
            {
                string[] parts = line.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                switch (command)
                {
                    case "Add":
                        string username = parts[1];
                        int sentMessages = int.Parse(parts[2]);
                        int receivedMessages = int.Parse(parts[3]);
                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, new int[] { sentMessages, receivedMessages });
                        }
                        break;
                    case "Message":
                        string sender = parts[1];
                        string receiver = parts[2];

                        if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                        {
                            users[sender][0] += 1;
                            users[receiver][1] += 1;

                            if (users[sender][0] + users[sender][1] >= capacity)
                            {
                                Console.WriteLine($"{sender} reached the capacity!");
                                users.Remove(sender);
                            }

                            if (users[receiver][0] + users[receiver][1] >= capacity)
                            {
                                Console.WriteLine($"{receiver} reached the capacity!");
                                users.Remove(receiver);
                            }
                        }
                        break;
                    case "Empty":
                        string user = parts[1];

                        if (users.ContainsKey(user))
                        {
                            users.Remove(user);
                        }

                        if (user == "All")
                        {
                            users.Clear();
                        }
                        break;
                    default:
                        break;
                }
                line = Console.ReadLine();
            }

            users = users
                .OrderByDescending(m => m.Value[1])
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} - {user.Value[0] + user.Value[1]}");
            }
        }
    }
}
