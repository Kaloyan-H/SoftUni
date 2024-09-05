using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsNum = int.Parse(Console.ReadLine());
            List<string> partyList = new List<string>();

            for (int i = 0; i < commandsNum; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (input[2])
                {
                    case "not":

                        if (!partyList.Remove(input[0]))
                        {
                            Console.WriteLine($"{input[0]} is not in the list!");
                        }

                        break;
                    case "going!":

                        if (!partyList.Contains(input[0]))
                        {
                            partyList.Add(input[0]);
                        }
                        else
                        {
                            Console.WriteLine($"{input[0]} is already in the list!");
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join("\n", partyList));
        }
    }
}
