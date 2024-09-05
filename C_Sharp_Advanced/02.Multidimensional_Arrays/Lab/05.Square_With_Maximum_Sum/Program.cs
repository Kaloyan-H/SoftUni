using System;

namespace _05.Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(cmdArgs[0]);
            int cols = int.Parse(cmdArgs[1]);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            int[,] twoByTwo = new int[2, 2];
            int highestSum = int.MinValue;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum = matrix[row, col]
                        + matrix[row + 1, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col + 1];

                    if (currentSum > highestSum)
                    {
                        highestSum = currentSum;

                        for (int row1 = 0; row1 < 2; row1++)
                        {
                            for (int col1 = 0; col1 < 2; col1++)
                            {
                                twoByTwo[row1, col1] = matrix[row + row1, col + col1];
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(twoByTwo[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(highestSum);
        }
    }
}
