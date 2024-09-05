using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Follower
    {
        public Follower() { }

        public Follower(string username, int likes, int comments)
        {
            this.Username = username;
            this.Likes = likes;
            this.Comments = comments;
        }

        public string Username { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Follower> followers = new List<Follower>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Log out")
                {
                    break;
                }

                string[] tokens = input
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "New follower":

                        bool existsNew = false;

                        foreach (var follower in followers)
                        {
                            if (tokens[1] == follower.Username)
                            {
                                existsNew = true;
                                break;
                            }
                        }

                        if (existsNew == false)
                        {
                            followers.Add(new Follower(
                                tokens[1],
                                0,
                                0));
                        }

                        break;

                    case "Like":

                        bool existsLike = false;

                        foreach (var follower in followers)
                        {
                            if (follower.Username == tokens[1])
                            {
                                follower.Likes += int.Parse(tokens[2]);

                                existsLike = true;

                                break;
                            }
                        }

                        if (existsLike == false)
                        {
                            followers.Add(new Follower(
                                tokens[1],
                                int.Parse(tokens[2]),
                                0));
                        }

                        break;

                    case "Comment":

                        bool existsComment = false;

                        foreach (var follower in followers)
                        {
                            if (follower.Username == tokens[1])
                            {
                                follower.Comments++;

                                existsComment = true;

                                break;
                            }
                        }

                        if (existsComment == false)
                        {
                            followers.Add(new Follower(
                                tokens[1],
                                0,
                                1));
                        }

                        break;

                    case "Blocked":

                        bool existsBlocked = false;

                        for (int i = 0; i < followers.Count; i++)
                        {
                            if (followers[i].Username == tokens[1])
                            {
                                followers.RemoveAt(i);

                                existsBlocked = true;

                                break;
                            }
                        }

                        if (existsBlocked == false)
                        {
                            Console.WriteLine($"{tokens[1]} doesn't exist.");
                        }

                        break;
                }
            }

            Console.WriteLine($"{followers.Count} followers");

            foreach (var follower in followers)
            {
                Console.WriteLine($"{follower.Username}: {follower.Likes + follower.Comments}");
            }
        }
    }
}
