using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerDeck = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerDeck = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            while (firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0)
            {
                if (firstPlayerDeck[0] > secondPlayerDeck[0])
                {
                    firstPlayerDeck.Add(firstPlayerDeck[0]);
                    firstPlayerDeck.Add(secondPlayerDeck[0]);
                }
                else if (firstPlayerDeck[0] < secondPlayerDeck[0])
                {
                    secondPlayerDeck.Add(secondPlayerDeck[0]);
                    secondPlayerDeck.Add(firstPlayerDeck[0]);
                }

                firstPlayerDeck.RemoveAt(0);
                secondPlayerDeck.RemoveAt(0);
            }

            if (firstPlayerDeck.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerDeck.Sum()}");
            }
        }
    }
}
