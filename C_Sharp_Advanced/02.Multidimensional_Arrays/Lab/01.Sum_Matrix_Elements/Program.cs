using System;
using System.Linq;

namespace _01.Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cmdArgs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowsNum = cmdArgs[0];
            int colsNum = cmdArgs[1];

            int[,] matrix = new int[rowsNum, colsNum];

            for (int row = 0; row < rowsNum; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < colsNum; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;

            foreach (var number in matrix)
            {
                sum += number;
            }

            Console.WriteLine($"{rowsNum}\n" +
                $"{colsNum}\n" +
                $"{sum}");
        }
    }
}
