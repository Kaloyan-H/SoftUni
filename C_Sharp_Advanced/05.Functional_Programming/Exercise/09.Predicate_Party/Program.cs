using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Predicate_Party
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> nameThenCount = new Dictionary<string, int>();

            string[] list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in list)
            {
                nameThenCount.Add(item, 1);
            }

            while (true)
            {
                string[] args = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "Party!")
                {
                    if (nameThenCount.Values.Sum() == 0)
                    {
                        Console.WriteLine("Nobody is going to the party!");
                    }
                    else
                    {
                        List<string> output = new List<string>();

                        foreach (var item in nameThenCount.Keys)
                        {
                            if (nameThenCount[item] > 0)
                            {
                                string temp = item;
                                for (int i = 0; i < nameThenCount[item] - 1; i++)
                                {
                                    temp += $", {item}";
                                }

                                output.Add(temp);
                            }
                        }

                        Console.WriteLine($"{string.Join(", ", output)} are going to the party!");
                    }

                    return;
                }

                string action = args[0];
                string filter = args[1];
                string token = args[2];


                switch (action)
                {
                    case "Remove":
                        switch (filter)
                        {
                            case "StartsWith":
                                List<string> keys1 = new List<string>(nameThenCount.Keys);
                                foreach (var item in keys1)
                                {
                                    if (item.StartsWith(token))
                                    {
                                        nameThenCount[item] = 0;
                                    }
                                }
                                break;

                            case "EndsWith":
                                List<string> keys2 = new List<string>(nameThenCount.Keys);
                                foreach (var item in keys2)
                                {
                                    if (item.EndsWith(token))
                                    {
                                        nameThenCount[item] = 0;
                                    }
                                }
                                break;

                            case "Length":
                                List<string> keys3 = new List<string>(nameThenCount.Keys);
                                foreach (var item in keys3)
                                {
                                    if (item.Length == int.Parse(token))
                                    {
                                        nameThenCount[item] = 0;
                                    }
                                }
                                break;
                        }
                        break;

                    case "Double":
                        switch (filter)
                        {
                            case "StartsWith":
                                List<string> keys1 = new List<string>(nameThenCount.Keys);
                                foreach (var item in keys1)
                                {
                                    if (item.StartsWith(token))
                                    {
                                        nameThenCount[item] *= 2;
                                    }
                                }
                                break;

                            case "EndsWith":
                                List<string> keys2 = new List<string>(nameThenCount.Keys);
                                foreach (var item in keys2)
                                {
                                    if (item.EndsWith(token))
                                    {
                                        nameThenCount[item] *= 2;
                                    }
                                }
                                break;

                            case "Length":
                                List<string> keys3 = new List<string>(nameThenCount.Keys);
                                foreach (var item in keys3)
                                {
                                    if (item.Length == int.Parse(token))
                                    {
                                        nameThenCount[item] *= 2;
                                    }
                                }
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
