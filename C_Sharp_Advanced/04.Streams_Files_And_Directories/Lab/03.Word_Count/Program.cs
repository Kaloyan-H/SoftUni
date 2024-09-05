using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(wordsFilePath);

            HashSet<string> set = reader.ReadToEnd()
                .Split(new string[] { " ", "\n", "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            reader.Close();

            Dictionary<string, int> wordsThenCount = new Dictionary<string, int>();

            foreach (var item in set)
            {
                wordsThenCount.Add(item, 0);
            }

            using (StreamReader reader1 = new StreamReader(textFilePath))
            {
                string[] line = reader1.ReadToEnd()
                    .Split(new string[] { " ", ".", ",", "!", "?", "-", "\n", "\"", "\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in line)
                {
                    if (wordsThenCount.ContainsKey(item))
                    {
                        wordsThenCount[item]++;
                    }
                }
            }

            wordsThenCount = wordsThenCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var item in wordsThenCount)
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}