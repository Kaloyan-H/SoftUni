using System;
using System.Linq;

namespace _10.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] initialLadybugPositions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < initialLadybugPositions.Length; i++)
            {
                if (initialLadybugPositions[i] < field.Length
                    && initialLadybugPositions[i] >= 0)
                {
                    field[initialLadybugPositions[i]] = 1;
                }
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int ladybugIndex = int.Parse(inputs[0]);
                string direction = inputs[1];
                int flyLength = int.Parse(inputs[2]);
                int counter = 0;

                if (ladybugIndex >= field.Length
                    || ladybugIndex < 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                else if (field[ladybugIndex] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                switch (direction)
                {
                    case "right":

                        while (true)
                        {

                            if (counter == 0)
                            {
                                if (ladybugIndex + flyLength >= field.Length
                                || ladybugIndex + flyLength < 0)
                                {
                                    field[ladybugIndex] = 0;
                                    break;
                                }
                                else if (field[ladybugIndex + flyLength] == 0)
                                {
                                    field[ladybugIndex] = 0;
                                    field[ladybugIndex + flyLength] = 1;
                                    counter++;
                                    break;
                                }
                                else
                                {
                                    field[ladybugIndex] = 0;
                                    ladybugIndex += flyLength;
                                    counter++;
                                }
                            }
                            else
                            {
                                if (ladybugIndex + flyLength >= field.Length
                                || ladybugIndex + flyLength < 0)
                                {
                                    break;
                                }
                                else if (field[ladybugIndex + flyLength] == 0)
                                {
                                    field[ladybugIndex + flyLength] = 1;
                                    counter++;
                                    break;
                                }
                                else
                                {
                                    ladybugIndex += flyLength;
                                    counter++;
                                }
                            }
                        }

                        break;
                    case "left":

                        while (true)
                        {
                            if (counter == 0)
                            {
                                if (ladybugIndex - flyLength >= field.Length
                                || ladybugIndex - flyLength < 0)
                                {
                                    field[ladybugIndex] = 0;
                                    break;
                                }
                                else if (field[ladybugIndex - flyLength] == 0)
                                {
                                    field[ladybugIndex] = 0;
                                    field[ladybugIndex - flyLength] = 1;
                                    counter++;
                                    break;
                                }
                                else
                                {
                                    field[ladybugIndex] = 0;
                                    ladybugIndex -= flyLength;
                                    counter++;
                                }
                            }
                            else
                            {
                                if (ladybugIndex - flyLength >= field.Length
                                || ladybugIndex - flyLength < 0)
                                {
                                    break;
                                }
                                else if (field[ladybugIndex - flyLength] == 0)
                                {
                                    field[ladybugIndex - flyLength] = 1;
                                    counter++;
                                    break;
                                }
                                else
                                {
                                    ladybugIndex -= flyLength;
                                    counter++;
                                }
                            }
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', field));
        }
    }
}
