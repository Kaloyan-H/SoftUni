using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWords = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> wordsAndSynonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordsAndSynonyms.ContainsKey(word))
                {
                    wordsAndSynonyms.Add(word, new List<string>());
                }

                wordsAndSynonyms[word].Add(synonym);
            }

            foreach (var element in wordsAndSynonyms)
            {
                Console.WriteLine($"{element.Key} - {string.Join(", ", element.Value)}");
            }
        }
    }
}
