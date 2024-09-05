using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
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

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }
        override public string  ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article(input[0], input[1], input[2]);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                switch (tokens[0])
                {
                    case "Edit:":

                        tokens.RemoveAt(0);
                        article.Edit(string.Join(' ', tokens));

                        break;

                    case "ChangeAuthor:":

                        tokens.RemoveAt(0);
                        article.ChangeAuthor(string.Join(' ', tokens));

                        break;

                    case "Rename:":

                        tokens.RemoveAt(0);
                        article.Rename(string.Join(' ', tokens));

                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}
