using System;

namespace _01.Sign_Of_Integer_Numbers
{
    class Program
    {
        static void NumberType(int n)
        {
            if (n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }
            else if (n < 0) 
            {
                Console.WriteLine($"The number {n} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {n} is zero.");
            }
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            NumberType(number);
        }
    }
}
