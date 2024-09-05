using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Truck_Tour
{
    class Program
    {
        class PetrolStation
        {
            public int PetrolAmount { get; set; }
            public int KilometresToNextStation { get; set; }

            public PetrolStation(int petrolAmount, int kilometresToNextStation)
            {
                this.PetrolAmount = petrolAmount;
                this.KilometresToNextStation = kilometresToNextStation;
            }
        }

        static void Main(string[] args)
        {
            int numberOfPetrolStations = int.Parse(Console.ReadLine());
            Queue<PetrolStation> stationsQueue = new Queue<PetrolStation>();

            for (int i = 0; i < numberOfPetrolStations; i++)
            {
                int[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                stationsQueue.Enqueue(new PetrolStation(cmdArgs[0], cmdArgs[1]));
            }

            while (true)
            {
                int currentPetrol = 0;
                bool startFound = true;

                for (int i = 0; i < stationsQueue.Count; i++)
                {
                    PetrolStation currentStation = stationsQueue.Dequeue();
                    currentPetrol += currentStation.PetrolAmount;
                    currentPetrol -= currentStation.KilometresToNextStation;
                    stationsQueue.Enqueue(currentStation);

                    if (currentPetrol < 0)
                    {
                        startFound = false;
                    }
                }

                if (startFound == true)
                {
                    break;
                }
                else
                {
                    stationsQueue.Dequeue();
                }
            }

            Console.WriteLine(numberOfPetrolStations - stationsQueue.Count);
        }
    }
}
