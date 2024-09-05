using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            bool changesHaveBeenMade = false;

            while (true)
            {
                string inputStr = Console.ReadLine();

                if (inputStr == "end")
                {
                    break;
                }

                string[] inputArr = inputStr.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (inputArr[0])
                {
                    case "Add":

                        numbers.Add(int.Parse(inputArr[1]));
                        changesHaveBeenMade = true;

                        break;
                    case "Remove":

                        numbers.Remove(int.Parse(inputArr[1]));
                        changesHaveBeenMade = true;

                        break;
                    case "RemoveAt":

                        numbers.RemoveAt(int.Parse(inputArr[1]));
                        changesHaveBeenMade = true;

                        break;
                    case "Insert":

                        numbers.Insert(int.Parse(inputArr[2]), int.Parse(inputArr[1]));
                        changesHaveBeenMade = true;

                        break;
                    case "Contains":
                        
                        if (numbers.Contains(int.Parse(inputArr[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }

                        break;
                    case "PrintEven":

                        List<int> tempEven = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                tempEven.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", tempEven));

                        break;
                    case "PrintOdd":

                        List<int> tempOdd = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                            {
                                tempOdd.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", tempOdd));

                        break;
                    case "GetSum":

                        Console.WriteLine(numbers.Sum());

                        break;
                    case "Filter":

                        switch (inputArr[1])
                        {
                            case "<":

                                List<int> tempLower = new List<int>();

                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] < int.Parse(inputArr[2]))
                                    {
                                        tempLower.Add(numbers[i]);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", tempLower));

                                break;
                            case "<=":

                                List<int> tempLowerEven = new List<int>();

                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] <= int.Parse(inputArr[2]))
                                    {
                                        tempLowerEven.Add(numbers[i]);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", tempLowerEven));

                                break;
                            case ">":

                                List<int> tempHigher = new List<int>();

                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] > int.Parse(inputArr[2]))
                                    {
                                        tempHigher.Add(numbers[i]);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", tempHigher));

                                break;
                            case ">=":

                                List<int> tempHigherEven = new List<int>();

                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] >= int.Parse(inputArr[2]))
                                    {
                                        tempHigherEven.Add(numbers[i]);
                                    }
                                }

                                Console.WriteLine(string.Join(" ", tempHigherEven));

                                break;
                        }

                        break;
                }
            }


            if (changesHaveBeenMade)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
