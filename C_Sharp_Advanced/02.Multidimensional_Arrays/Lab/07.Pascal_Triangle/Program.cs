using System;

namespace _07.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[size][];
            pascalTriangle[0] = new long[1] { 1 };

            for (int row = 1; row < size; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    if (col - 1 < 0 || col >= pascalTriangle[row - 1].Length)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                    else
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col] + pascalTriangle[row - 1][col - 1];
                    }
                }
            }

            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                Console.WriteLine(string.Join(' ', pascalTriangle[row]));
            }
        }
    }
}
