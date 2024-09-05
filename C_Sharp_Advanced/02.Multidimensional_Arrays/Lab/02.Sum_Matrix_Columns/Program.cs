using System;
using System.Linq;

namespace _02.Sum_Matrix_Columns
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
            int[] colSums = new int[colsNum];

            for (int row = 0; row < rowsNum; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < colsNum; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int col = 0; col < colsNum; col++)
            {
                for (int row = 0; row < rowsNum; row++)
                {
                    colSums[col] += matrix[row, col];
                }
            }

            foreach (var sum in colSums)
            {
                Console.WriteLine(sum);
            }
        }
    }
}
