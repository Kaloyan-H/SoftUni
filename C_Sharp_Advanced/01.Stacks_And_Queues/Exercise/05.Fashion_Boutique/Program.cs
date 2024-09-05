using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int numberOfRacksNeeded = 1;
            int tempRack = 0;

            Stack<int> stack = new Stack<int>();

            foreach (var pieceOfClothing in clothes)
            {
                stack.Push(pieceOfClothing);
            }

            while (stack.Count > 0)
            {
                if (tempRack + stack.Peek() > rackCapacity)
                {
                    tempRack = 0 + stack.Pop();
                    numberOfRacksNeeded++;
                    continue;
                }

                tempRack += stack.Pop();
            }

            Console.WriteLine(numberOfRacksNeeded);
        }
    }
}
