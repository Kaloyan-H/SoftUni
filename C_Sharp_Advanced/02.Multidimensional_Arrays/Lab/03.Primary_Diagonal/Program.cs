using System;

namespace _03.Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            int sum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                string[] line = Console.ReadLine().Split();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);

                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
