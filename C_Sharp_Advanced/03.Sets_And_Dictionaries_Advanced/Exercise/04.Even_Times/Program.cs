using System;
using System.Collections.Generic;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, int> numberThenCount = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                if (!numberThenCount.ContainsKey(input))
                {
                    numberThenCount.Add(input, 0);
                }

                numberThenCount[input]++;
            }

            foreach (var item in numberThenCount)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    return;
                }
            }
        }
    }
}
