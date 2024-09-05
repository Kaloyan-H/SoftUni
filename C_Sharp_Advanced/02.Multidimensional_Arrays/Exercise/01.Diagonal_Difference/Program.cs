using System;

namespace _01.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                string[] line = Console.ReadLine()
                    .Split();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);

                    if (row == col)
                    {
                        firstDiagonalSum += matrix[row, col];
                    }
                    if (row == sizeOfMatrix - 1 - col)
                    {
                        secondDiagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
