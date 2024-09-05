using System;

namespace _07.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            bool hasKnightsAttacked = true;
            int knightsRemoved = 0;

            while (hasKnightsAttacked)
            {
                int countAttackingMost = 0;
                int rowAttackingMost = 0;
                int colAttackingMost = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int countAttackingCurrent = 0;

                        if (matrix[row, col] == 'K')
                        {
                            //
                            //up-left
                            if (row - 2 >= 0
                                && col - 1 >= 0
                                && matrix[row - 2, col - 1] == 'K')
                            {
                                countAttackingCurrent++;
                            }
                            //up-right
                            if (row - 2 >= 0
                                && col + 1 < size
                                && matrix[row - 2, col + 1] == 'K')
                            {
                                countAttackingCurrent++;
                            }

                            //
                            //right-up
                            if (row - 1 >= 0
                                && col + 2 < size
                                && matrix[row - 1, col + 2] == 'K')
                            {
                                countAttackingCurrent++;
                            }
                            //right-down
                            if (row + 1 < size
                                && col + 2 < size
                                && matrix[row + 1, col + 2] == 'K')
                            {
                                countAttackingCurrent++;
                            }

                            //
                            //down-left
                            if (row + 2 < size
                                && col - 1 >= 0
                                && matrix[row + 2, col - 1] == 'K')
                            {
                                countAttackingCurrent++;
                            }
                            //down-right
                            if (row + 2 < size
                                && col + 1 < size
                                && matrix[row + 2, col + 1] == 'K')
                            {
                                countAttackingCurrent++;
                            }

                            //
                            //left-up
                            if (row - 1 >= 0
                                && col - 2 >= 0
                                && matrix[row - 1, col - 2] == 'K')
                            {
                                countAttackingCurrent++;
                            }
                            //left-down
                            if (row + 1 < size
                                && col - 2 >= 0
                                && matrix[row + 1, col - 2] == 'K')
                            {
                                countAttackingCurrent++;
                            }
                        }
                        

                        if (countAttackingCurrent > countAttackingMost)
                        {
                            countAttackingMost = countAttackingCurrent;
                            rowAttackingMost = row;
                            colAttackingMost = col;
                        }
                    }
                }

                if (countAttackingMost == 0)
                {
                    hasKnightsAttacked = false;
                }
                else
                {
                    matrix[rowAttackingMost, colAttackingMost] = '0';
                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);
        }
    }
}
