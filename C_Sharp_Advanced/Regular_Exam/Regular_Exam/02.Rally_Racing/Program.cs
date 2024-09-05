using System;
using System.Linq;


namespace _02.Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            int kilometresTravelled = 0;
            char[,] racetrack = new char[matrixSize, matrixSize];
            bool finished = false;
            Coordinates tunnelOneCoordinates = new Coordinates(-1, -1);
            Coordinates tunnelTwoCoordinates = new Coordinates(-1, -1);
            Coordinates finishLineCoordinates = new Coordinates();
            Coordinates carCoordinates = new Coordinates(0, 0);


            for (int row = 0; row < matrixSize; row++)
            {
                char[] raceRoute = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    racetrack[row, col] = raceRoute[col];
                    if (raceRoute[col] == 'T')
                    {
                        if (tunnelOneCoordinates.X == -1)
                        {
                            tunnelOneCoordinates.Y = row;
                            tunnelOneCoordinates.X = col;
                        }
                        else
                        {
                            tunnelTwoCoordinates.Y = row;
                            tunnelTwoCoordinates.X = col;
                        }
                    }
                    else if (raceRoute[col] == 'F')
                    {
                        finishLineCoordinates.Y = row;
                        finishLineCoordinates.X = col;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    if (!finished)
                    {
                        Console.WriteLine($"Racing car {racingNumber} DNF.{Environment.NewLine}" +
                        $"Distance covered {kilometresTravelled} km.");
                        racetrack[carCoordinates.Y, carCoordinates.X] = 'C';

                        for (int row = 0; row < matrixSize; row++)
                        {
                            for (int col = 0; col < matrixSize; col++)
                            {
                                Console.Write(racetrack[row, col]);
                            }
                            Console.WriteLine();
                        }
                    }

                    return;
                }
                if (finished)
                {
                    continue;
                }
                Coordinates coordinatesToTravelTo = new Coordinates();

                switch (input)
                {
                    case "left":

                        coordinatesToTravelTo.X = carCoordinates.X - 1;
                        coordinatesToTravelTo.Y = carCoordinates.Y;

                        break;
                    case "right":

                        coordinatesToTravelTo.X = carCoordinates.X + 1;
                        coordinatesToTravelTo.Y = carCoordinates.Y;

                        break;
                    case "up":

                        coordinatesToTravelTo.Y = carCoordinates.Y - 1;
                        coordinatesToTravelTo.X = carCoordinates.X;

                        break;
                    case "down":

                        coordinatesToTravelTo.Y = carCoordinates.Y + 1;
                        coordinatesToTravelTo.X = carCoordinates.X;

                        break;
                }

                if (coordinatesToTravelTo == tunnelOneCoordinates)
                {
                    carCoordinates = tunnelTwoCoordinates;
                    racetrack[tunnelOneCoordinates.Y, tunnelOneCoordinates.X] = '.';
                    racetrack[tunnelTwoCoordinates.Y, tunnelTwoCoordinates.X] = '.';
                    kilometresTravelled += 30;
                }
                else if (coordinatesToTravelTo == tunnelTwoCoordinates)
                {
                    carCoordinates = tunnelOneCoordinates;
                    racetrack[tunnelOneCoordinates.Y, tunnelOneCoordinates.X] = '.';
                    racetrack[tunnelTwoCoordinates.Y, tunnelTwoCoordinates.X] = '.';
                    kilometresTravelled += 30;
                }
                else if (coordinatesToTravelTo == finishLineCoordinates)
                {
                    carCoordinates = finishLineCoordinates;
                    racetrack[finishLineCoordinates.Y, finishLineCoordinates.X] = '.';
                    finished = true;
                    kilometresTravelled += 10;

                    Console.WriteLine($"Racing car {racingNumber} finished the stage!{Environment.NewLine}" +
                        $"Distance covered {kilometresTravelled} km.");

                    racetrack[carCoordinates.Y, carCoordinates.X] = 'C';

                    for (int row = 0; row < matrixSize; row++)
                    {
                        for (int col = 0; col < matrixSize; col++)
                        {
                            Console.Write(racetrack[row, col]);
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    carCoordinates = coordinatesToTravelTo;
                    kilometresTravelled += 10;
                }
            }
        }

        struct Coordinates
        {
            public int X;
            public int Y;

            public Coordinates(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static bool operator ==(Coordinates coordinatesOne, Coordinates coordinatesTwo) =>
                coordinatesOne.X == coordinatesTwo.X && coordinatesOne.Y == coordinatesTwo.Y;
            public static bool operator !=(Coordinates coordinatesOne, Coordinates coordinatesTwo) =>
                coordinatesOne.X != coordinatesTwo.X || coordinatesOne.Y != coordinatesTwo.Y;
        }
    }
}
