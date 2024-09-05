using System;
using System.Linq;

namespace _02.Knights_Of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = s => Console.WriteLine(string.Join("\n", s));

            print(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => "Sir " + s)
                .ToArray());
        }
    }
}
