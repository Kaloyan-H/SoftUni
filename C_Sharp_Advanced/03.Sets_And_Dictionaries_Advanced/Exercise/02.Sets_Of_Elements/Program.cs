using System;
using System.Collections.Generic;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
                .Split();

            int firstSetLength = int.Parse(cmdArgs[0]);
            int secondSetLength = int.Parse(cmdArgs[1]);

            HashSet<string> firstSet = new HashSet<string>();
            HashSet<string> secondSet = new HashSet<string>();
            List<string> commonElements = new List<string>();

            for (int i = 0; i < firstSetLength; i++)
            {
                string input = Console.ReadLine();
                firstSet.Add(input);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                string input = Console.ReadLine();
                secondSet.Add(input);
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    commonElements.Add(item);
                }
            }

            Console.WriteLine(string.Join(' ', commonElements));
        }
    }
}
