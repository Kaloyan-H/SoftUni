using System;
using System.Collections.Generic;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                set.Add(input);
            }

            Console.WriteLine(string.Join("\n", set));
        }
    }
}
