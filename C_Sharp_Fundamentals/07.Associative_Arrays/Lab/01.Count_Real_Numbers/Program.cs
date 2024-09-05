using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> countByNumber = new SortedDictionary<int, int>();

            foreach (var number in numbers)
            {
                if (!countByNumber.ContainsKey(number))
                {
                    countByNumber.Add(number, 0);
                }

                countByNumber[number]++;
            }

            foreach (var keyValuePair in countByNumber)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
