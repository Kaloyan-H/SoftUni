using System;
using System.Linq;

namespace _06.Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            while (true)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split();

                if (cmdArgs[0] == "END")
                {
                    break;
                }

                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row >= rows || row < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                else if (col >= matrix[row].Count() || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (cmdArgs[0])
                {
                    case "Add":

                        matrix[row][col] += value;

                        break;

                    case "Subtract":

                        matrix[row][col] -= value;

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
