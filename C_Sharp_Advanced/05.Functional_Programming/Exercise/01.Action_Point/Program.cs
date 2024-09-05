using System;
using System.Linq;

namespace _01.Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = s => Console.WriteLine(string.Join("\n", s));

            print(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
