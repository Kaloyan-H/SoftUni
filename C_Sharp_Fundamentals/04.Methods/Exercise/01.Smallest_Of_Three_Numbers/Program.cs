using System;

namespace _01.Smallest_Of_Three_Numbers
{
    class Program
    {
        static int SmallestOfThree(int first, int second, int third)
        {
            return Math.Min(Math.Min(first, second), third);
        }
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestOfThree(first, second, third));
        }
    }
}
