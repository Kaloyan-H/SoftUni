using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Friend_List_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friendList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (input[0])
                {
                    case "Blacklist":

                        if (friendList.Contains(input[1]))
                        {
                            friendList[friendList.IndexOf(input[1])] = "Blacklisted";
                            Console.WriteLine($"{input[1]} was blacklisted.");
                        }
                        else
                        {
                            Console.WriteLine($"{input[1]} was not found.");
                        }

                        break;
                    case "Error":
                        if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < friendList.Count
                            && friendList[int.Parse(input[1])] != "Blacklisted" && friendList[int.Parse(input[1])] != "Lost")
                        {
                            Console.WriteLine($"{friendList[int.Parse(input[1])]} was lost due to an error.");
                            friendList[int.Parse(input[1])] = "Lost";
                        }
                        break;
                    case "Change":
                        if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < friendList.Count)
                        {
                            Console.WriteLine($"{friendList[int.Parse(input[1])]} changed his username to {input[2]}.");
                            friendList[int.Parse(input[1])] = input[2];
                        }
                        break;
                    case "Report":

                        int lostNames = 0;
                        int blacklistedNames = 0;

                        for (int i = 0; i < friendList.Count; i++)
                        {
                            if (friendList[i] == "Lost")
                            {
                                lostNames++;
                            }
                            if (friendList[i] == "Blacklisted")
                            {
                                blacklistedNames++;
                            }
                        }

                        Console.WriteLine($"Blacklisted names: {blacklistedNames}\n" +
                            $"Lost names: {lostNames}\n" +
                            $"{string.Join(" ", friendList)}");

                        return;
                }

            }
        }
    }
}
