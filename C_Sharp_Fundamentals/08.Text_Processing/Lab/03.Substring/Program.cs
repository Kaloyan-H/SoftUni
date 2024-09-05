using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(key))
            {
                text = text.Remove(text.IndexOf(key), key.Length);
            }

            Console.WriteLine(text);
        }
    }
}
