using System;
using System.Linq;

namespace _07.Max_Sequence_Of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int counter = 1;
            int longestSequenceLength = 0;
            int longestSequenceNumber = 0;
            int currentSequenceLength = 0;
            int currentSequenceNumber = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                int temp = numbers[i - 1];

                if (temp == numbers[i])
                {
                    counter++;
                }
                else
                {
                    currentSequenceLength = counter;
                    currentSequenceNumber = temp;

                    if (currentSequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = currentSequenceLength;
                        longestSequenceNumber = currentSequenceNumber;
                    }

                    counter = 1;
                }

                if (i == numbers.Length - 1)
                {
                    currentSequenceLength = counter;
                    currentSequenceNumber = temp;

                    if (currentSequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = currentSequenceLength;
                        longestSequenceNumber = currentSequenceNumber;
                    }
                }
            }

            for (int i = 0; i < longestSequenceLength; i++)
            {
                Console.Write(longestSequenceNumber + " ");
            }
        }
    }
}
