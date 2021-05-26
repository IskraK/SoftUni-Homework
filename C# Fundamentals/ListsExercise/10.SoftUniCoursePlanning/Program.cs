using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] commands = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                string lessonTitle = commands[1];
                switch (command)
                {
                    case "Add":
                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Insert(int.Parse(commands[2]), lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (lessons.Contains(lessonTitle))
                        {
                            lessons.Remove(lessonTitle);
                            if (lessons.Contains($"{lessonTitle}-Exercise"))
                            {
                                lessons.Remove($"{lessonTitle}-Exercise");
                            }
                        }
                        break;
                    case "Swap":
                        string secondLesson = commands[2];

                        if (lessons.Contains(lessonTitle) && lessons.Contains(secondLesson))
                        {
                            int idx1 = lessons.IndexOf(lessonTitle);
                            int idx2 = lessons.IndexOf(secondLesson);
                            lessons[idx1] = secondLesson;
                            lessons[idx2] = lessonTitle;

                            if (lessons.Contains($"{lessonTitle}-Exercise"))
                            {
                                lessons.Remove($"{lessonTitle}-Exercise");
                                lessons.Insert(idx2 + 1, $"{lessonTitle}-Exercise");
                            }

                            if (lessons.Contains($"{secondLesson}-Exercise"))
                            {
                                lessons.Remove($"{secondLesson}-Exercise");
                                lessons.Insert(idx1 + 1, $"{secondLesson}-Exercise");
                            }
                        }
                        break;
                    case "Exercise":
                        if (!lessons.Contains($"{lessonTitle}-Exercise"))
                        {
                            if (lessons.Contains(lessonTitle))
                            {
                                int idx = lessons.IndexOf(lessonTitle);
                                lessons.Insert(idx + 1, $"{lessonTitle}-Exercise");
                            }
                            else
                            {
                                lessons.Add(lessonTitle);
                                lessons.Add($"{lessonTitle}-Exercise");
                            }
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
