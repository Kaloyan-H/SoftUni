using System;

namespace _03.Characters_In_Range
{
    class Program
    {
        static void PrintCharsInRange(char first, char second)
        {
            if (first < second)
            {
                for (int i = first + 1; i < second; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = second + 1; i < first; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            PrintCharsInRange(first, second);
        }
    }
}
