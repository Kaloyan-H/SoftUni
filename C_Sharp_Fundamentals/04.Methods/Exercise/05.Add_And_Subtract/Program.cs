using System;

namespace _05.Add_And_Subtract
{
    class Program
    {
        static int Sum(int first, int second) => first + second;

        static int Subtract(int first, int second) => first - second;

        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(Sum(num1, num2), num3));
        }
    }
}
