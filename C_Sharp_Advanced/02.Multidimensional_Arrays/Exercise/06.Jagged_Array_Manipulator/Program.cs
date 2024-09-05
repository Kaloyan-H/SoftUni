using System;
using System.Linq;

namespace _06.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split();

                if (cmdArgs[0] == "End")
                {
                    break;
                }

                switch (cmdArgs[0])
                {
                    case "Add":

                        int row1 = int.Parse(cmdArgs[1]);
                        int col1 = int.Parse(cmdArgs[2]);

                        if (row1 < rows 
                            && row1 >= 0
                            && col1 >= 0
                            && col1 < matrix[row1].Length)
                        {
                            matrix[row1][col1] += double.Parse(cmdArgs[3]);
                        }

                        break;

                    case "Subtract":

                        int row = int.Parse(cmdArgs[1]);
                        int col = int.Parse(cmdArgs[2]);

                        if (row < rows
                            && row >= 0
                            && col >= 0
                            && col < matrix[row].Length)
                        {
                            matrix[row][col] -= double.Parse(cmdArgs[3]);
                        }

                        break;

                    default:
                        break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row]));
            }
        }
    }
}
