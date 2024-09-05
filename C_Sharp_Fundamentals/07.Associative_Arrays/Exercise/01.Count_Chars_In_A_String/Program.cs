using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Count_Chars_In_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> countByChars = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var character in input)
            {
                if (character != ' ')
                {
                    if (!countByChars.Keys.Contains(character))
                    {
                        countByChars.Add(character, 0);
                    }

                    countByChars[character]++;
                }
            }

            foreach (var pair in countByChars)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
