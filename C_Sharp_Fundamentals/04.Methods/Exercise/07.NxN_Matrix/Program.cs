using System;

namespace _07.NxN_Matrix
{
    class Program
    {
        static void PrintNxNMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintNxNMatrix(number);
        }
    }
}
