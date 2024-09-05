using System;

namespace _03.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
                .Split();
            int rows = int.Parse(cmdArgs[0]);
            int cols = int.Parse(cmdArgs[1]);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine()
                    .Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            int[,] highestTBT = new int[3, 3];

            int[] highestSumIndexes = new int[2];
            int highestSum = int.MinValue;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = 0;

                    for (int rowInner = 0; rowInner < 3; rowInner++)
                    {
                        for (int colInner = 0; colInner < 3; colInner++)
                        {
                            currentSum += matrix[row + rowInner, col + colInner];
                        }
                    }

                    if (currentSum > highestSum)
                    {
                        highestSumIndexes[0] = row;
                        highestSumIndexes[1] = col;
                        highestSum = currentSum;
                    }
                }
            }

            for (int rowInner = 0; rowInner < 3; rowInner++)
            {
                for (int colInner = 0; colInner < 3; colInner++)
                {
                    highestTBT[rowInner, colInner] = matrix[rowInner + highestSumIndexes[0], colInner + highestSumIndexes[1]];
                }
            }

            Console.WriteLine($"Sum = {highestSum}");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(highestTBT[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
