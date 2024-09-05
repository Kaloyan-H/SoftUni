using System;

namespace _04.Reverse_Array_Of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(input);

            Console.WriteLine(string.Join(' ', input));
        }
    }
}
