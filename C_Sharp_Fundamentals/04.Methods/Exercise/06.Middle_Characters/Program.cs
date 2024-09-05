using System;

namespace _06.Middle_Characters
{
    class Program
    {
        static void PrintMiddleChars(string text)
        {
            if (text.Length % 2 == 0)
            {
                Console.WriteLine($"{text[text.Length / 2 - 1]}{text[text.Length / 2]}");
            }
            else
            {
                Console.WriteLine(text[text.Length / 2]);
            }
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChars(input);
        }
    }
}
