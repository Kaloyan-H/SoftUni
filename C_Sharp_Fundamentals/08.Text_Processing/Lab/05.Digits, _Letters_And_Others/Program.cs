using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Digits___Letters_And_Others
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<char> digits = new List<char>();
            List<char> letters = new List<char>();
            List<char> characters = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 48 && text[i] <= 57)
                {
                    digits.Add(text[i]);
                }
                else if ((text[i] >= 65 && text[i] <= 90)
                    || (text[i] >= 97 && text[i] <= 122))
                {
                    letters.Add(text[i]);
                }
                else
                {
                    characters.Add(text[i]);
                }
            }

            Console.WriteLine($"{string.Join("", digits)}\n" +
                $"{string.Join("", letters)}\n" +
                $"{string.Join("", characters)}");
        }
    }
}
