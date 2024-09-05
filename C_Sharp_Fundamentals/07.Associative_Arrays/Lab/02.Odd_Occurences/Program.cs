using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Odd_Occurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> countByElements = new Dictionary<string, int>();

            foreach (var element in elements)
            {
                if (!countByElements.ContainsKey(element))
                {
                    countByElements.Add(element, 0);
                }

                countByElements[element]++;
            }

            List<string> oddNumberElements = new List<string>();

            foreach (var element in countByElements.Keys)
            {
                if (!oddNumberElements.Contains(element) && countByElements[element] % 2 != 0)
                {
                    oddNumberElements.Add(element.ToLower());
                }
            }

            Console.WriteLine(string.Join(' ', oddNumberElements));
        }
    }
}
