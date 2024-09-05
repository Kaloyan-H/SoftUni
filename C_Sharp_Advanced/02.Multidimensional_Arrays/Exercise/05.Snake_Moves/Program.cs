using System;
using System.Collections.Generic;

namespace _05.Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine()
                .Split();
            int rows = int.Parse(cmdArgs[0]);
            int cols = int.Parse(cmdArgs[1]);
            string text = Console.ReadLine();
            string[,] matrix = new string[rows, cols];
            Queue<string> queue = new Queue<string>();

            foreach (var item in text)
            {
                queue.Enqueue(item.ToString());
            }


            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
