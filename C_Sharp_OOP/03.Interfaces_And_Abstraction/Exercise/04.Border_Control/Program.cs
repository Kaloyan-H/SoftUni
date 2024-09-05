using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Border_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ids = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                ids.Add(input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Last());
            }

            string fakeIdKey = Console.ReadLine();

            foreach (var id in ids)
            {
                if (id.Substring(id.Length - fakeIdKey.Length) == fakeIdKey) Console.WriteLine(id);
            }
        }
    }
}
