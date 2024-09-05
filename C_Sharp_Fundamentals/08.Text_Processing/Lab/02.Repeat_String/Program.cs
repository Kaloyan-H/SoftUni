using System;

namespace _02.Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();

            string result = string.Empty;

            foreach (var word in text)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
