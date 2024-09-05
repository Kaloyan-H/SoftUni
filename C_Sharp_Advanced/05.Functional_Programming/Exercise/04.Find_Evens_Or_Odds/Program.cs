using System;
using System.Linq;

namespace _04.Find_Evens_Or_Odds
{
    class Program
    {
        public static void Find(int x, int y, Predicate<int> filter)
        {
            if (filter(x))
            {
                if (x < y)
                {
                    Console.Write(x + " ");
                }
                else
                {
                    Console.Write(x);
                }
            }

            if (x < y)
            {
                Find(x + 1, y, filter);
            }
        }

        static void Main(string[] args)
        {
            int[] cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int upperBound = 0;
            int lowerBound = 0;

            if (cmdArgs[0] < cmdArgs[1])
            {
                lowerBound = cmdArgs[0];
                upperBound = cmdArgs[1];
            }
            else
            {
                lowerBound = cmdArgs[1];
                upperBound = cmdArgs[0];
            }

            string filter = Console.ReadLine();

            Predicate<int> isEven = i => i % 2 == 0;
            Predicate<int> isOdd = i => i % 2 != 0;

            switch (filter)
            {
                case "even":

                    Find(lowerBound, upperBound, isEven);

                    break;

                case "odd":

                    Find(lowerBound, upperBound, isOdd);

                    break;

                default:
                    break;
            }
        }
    }
}
