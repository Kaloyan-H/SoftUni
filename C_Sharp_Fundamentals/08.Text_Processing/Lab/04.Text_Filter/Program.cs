using System;

namespace _04.Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            while (true)
            {
                bool textIsClear = true;

                foreach (var bannedWord in bannedWords)
                {
                    if (text.Contains(bannedWord))
                    {
                        text = text.Replace(bannedWord, new string('*', bannedWord.Length));
                        textIsClear = false;
                    }
                }

                if (textIsClear == true)
                {
                    break;
                }
            }

            Console.WriteLine(text);
        }
    }
}
