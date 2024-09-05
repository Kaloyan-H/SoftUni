using System;
using System.Linq;

namespace _02.Vowels_Count
{
    class Program
    {
        static int VowelCount(string input)
        {
            return input.Count(vowels => "aouei".Contains(vowels));
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            Console.WriteLine(VowelCount(input));
        }
    }
}
