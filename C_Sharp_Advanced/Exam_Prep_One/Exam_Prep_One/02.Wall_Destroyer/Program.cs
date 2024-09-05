using System;

namespace _02.Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());

            char[,] wall = new char[wallSize, wallSize];

            for (int row = 0; row < wallSize; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < wallSize; col++)
                {
                    wall[row, col] = input[col];
                }
            }

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < wallSize; row++)
            {
                for (int col = 0; col < wallSize; col++)
                {
                    if (wall[row, col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                        break;
                    }
                }
            }

            int rodsHit = 0;
            int holesMade = 1;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "up":

                        if (currentRow - 1 < 0) { }
                        else if (wall[currentRow - 1, currentCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;
                        }
                        else if (wall[currentRow - 1, currentCol] == 'C')
                        {
                            wall[currentRow - 1, currentCol] = 'E';
                            holesMade++;
                            wall[currentRow, currentCol] = '*';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            for (int row = 0; row < wallSize; row++)
                            {
                                for (int col = 0; col < wallSize; col++)
                                {
                                    Console.Write(wall[row, col]);
                                }
                                Console.WriteLine();
                            }
                            return;
                        }
                        else if (wall[currentRow - 1, currentCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{currentRow - 1}, {currentCol}]!");
                            wall[currentRow - 1, currentCol] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentRow--;
                        }
                        else
                        {
                            holesMade++;
                            wall[currentRow - 1, currentCol] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentRow--;
                        }

                        break;
                    case "down":

                        if (currentRow + 1 >= wallSize) { }
                        else if (wall[currentRow + 1, currentCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;
                        }
                        else if (wall[currentRow + 1, currentCol] == 'C')
                        {
                            wall[currentRow + 1, currentCol] = 'E';
                            holesMade++;
                            wall[currentRow, currentCol] = '*';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            for (int row = 0; row < wallSize; row++)
                            {
                                for (int col = 0; col < wallSize; col++)
                                {
                                    Console.Write(wall[row, col]);
                                }
                                Console.WriteLine();
                            }
                            return;
                        }
                        else if (wall[currentRow + 1, currentCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{currentRow + 1}, {currentCol}]!");
                            wall[currentRow + 1, currentCol] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentRow++;
                        }
                        else
                        {
                            holesMade++;
                            wall[currentRow + 1, currentCol] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentRow++;
                        }

                        break;
                    case "left":

                        if (currentCol - 1 < 0) { }
                        else if (wall[currentRow, currentCol - 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;
                        }
                        else if (wall[currentRow, currentCol - 1] == 'C')
                        {
                            wall[currentRow, currentCol - 1] = 'E';
                            holesMade++;
                            wall[currentRow, currentCol] = '*';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            for (int row = 0; row < wallSize; row++)
                            {
                                for (int col = 0; col < wallSize; col++)
                                {
                                    Console.Write(wall[row, col]);
                                }
                                Console.WriteLine();
                            }
                            return;
                        }
                        else if (wall[currentRow, currentCol - 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol - 1}]!");
                            wall[currentRow, currentCol - 1] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentCol--;
                        }
                        else
                        {
                            holesMade++;
                            wall[currentRow, currentCol - 1] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentCol--;
                        }

                        break;
                    case "right":

                        if (currentCol + 1 >= wallSize) { }
                        else if (wall[currentRow, currentCol + 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodsHit++;
                        }
                        else if (wall[currentRow, currentCol + 1] == 'C')
                        {
                            wall[currentRow, currentCol + 1] = 'E';
                            holesMade++;
                            wall[currentRow, currentCol] = '*';
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                            for (int row = 0; row < wallSize; row++)
                            {
                                for (int col = 0; col < wallSize; col++)
                                {
                                    Console.Write(wall[row, col]);
                                }
                                Console.WriteLine();
                            }
                            return;
                        }
                        else if (wall[currentRow, currentCol + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol + 1}]!");
                            wall[currentRow, currentCol + 1] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentCol++;
                        }
                        else
                        {
                            holesMade++;
                            wall[currentRow, currentCol + 1] = 'V';
                            wall[currentRow, currentCol] = '*';
                            currentCol++;
                        }

                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHit} rod(s).");

            for (int row = 0; row < wallSize; row++)
            {
                for (int col = 0; col < wallSize; col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
