using System;

namespace _02.Squares_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
                .Split();

            int rows = int.Parse(cmdArgs[0]);
            int cols = int.Parse(cmdArgs[1]);

            string[,] matrix = new string[rows, cols];
            int squareCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine()
                    .Split();
                    
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        squareCounter++;
                    }
                }
            }

            Console.WriteLine(squareCounter);
        }
    }
}
