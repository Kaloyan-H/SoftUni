using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> charThenCount = new Dictionary<char, int>();

            foreach (var item in text)
            {
                if (!charThenCount.ContainsKey(item))
                {
                    charThenCount.Add(item, 0);
                }

                charThenCount[item]++;
            }

            charThenCount = charThenCount
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in charThenCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
