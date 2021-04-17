using System;
using System.Text;

namespace _5.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            result.AppendLine("<h1>");
            result.AppendLine($"    {title}");
            result.AppendLine("</h1>");
            result.AppendLine("<article>");
            result.AppendLine($"    { content}");
            result.AppendLine("</article>");

            string comment = Console.ReadLine();

            while (comment != "end of comments")
            {
                result.AppendLine("<div>");
                result.AppendLine($"    {comment}");
                result.AppendLine("</div>");

                comment = Console.ReadLine();
            }

            Console.WriteLine(result);
        }
    }
}
