using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Chat_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (input[0])
                {
                    case "Chat":

                        chat.Add(input[1]);

                        break;
                    case "Delete":

                        chat.Remove(input[1]);

                        break;
                    case "Edit":

                        if (chat.Contains(input[1]))
                        {
                            chat[chat.IndexOf(input[1])] = input[2];
                        }

                        break;
                    case "Pin":

                        chat.Add(chat[chat.IndexOf(input[1])]);
                        chat.RemoveAt(chat.IndexOf(input[1]));

                        break;
                    case "Spam":

                        for (int i = 1; i < input.Length; i++)
                        {
                            chat.Add(input[i]);
                        }

                        break;
                    case "end":

                        Console.WriteLine(string.Join("\n", chat));

                        return;
                }
            }
        }
    }
}
