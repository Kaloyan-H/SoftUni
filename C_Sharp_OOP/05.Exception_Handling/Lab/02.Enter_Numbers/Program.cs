using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            while (numbers.Count < 10)
            {
                try
                {
                    if (numbers.Count == 0)
                    {
                        numbers.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        numbers.Add(ReadNumber(numbers[numbers.Count - 1], 100));
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            int number;

            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid Number!");
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return number;
        }
    }
}
