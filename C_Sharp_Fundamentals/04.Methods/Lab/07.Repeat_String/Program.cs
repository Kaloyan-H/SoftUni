using System;
using System.Text;

namespace _07.Repeat_String
{
    class Program
    {
        static string RepeatString(string str, int n)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                output.Append(str);
            }

            return output.ToString();
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(input, n));
        }
    }
}
