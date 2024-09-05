using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles_2._0
{
    class Article
    {
        public Article() { }
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfArticles = int.Parse(Console.ReadLine());

            Article[] articles = new Article[numberOfArticles];

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                articles[i] = new Article(tokens[0], tokens[1], tokens[2]);
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
}
