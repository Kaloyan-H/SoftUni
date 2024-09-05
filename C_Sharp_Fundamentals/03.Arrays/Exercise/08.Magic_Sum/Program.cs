using System;
using System.Linq;

namespace _08.Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i == j 
                        || numbers[i] == int.MinValue 
                        || numbers[j] == int.MinValue)
                    {
                        continue;
                    }

                    if (numbers[i] + numbers[j] == sum)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                        numbers[i] = int.MinValue;
                        numbers[j] = int.MinValue;
                    }
                }
            }
        }
    }
}
