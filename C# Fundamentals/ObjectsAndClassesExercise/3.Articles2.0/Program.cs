using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Articles2._0
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] articleData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Article article = new Article
                {
                    Title = articleData[0],
                    Content = articleData[1],
                    Author = articleData[2]
                };

                articles.Add(article);
            }

            List<Article> sorted = new List<Article>();
            string sortingParameter = Console.ReadLine();

            if (sortingParameter == "title")
            {
                sorted = articles.OrderBy(x => x.Title).ToList();
            }
            else if (sortingParameter == "content")
            {
                sorted = articles.OrderBy(x => x.Content).ToList();
            }
            else
            {
                sorted = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (var article in sorted)
            {
                Console.WriteLine(article);
            }
        }
    }
}
