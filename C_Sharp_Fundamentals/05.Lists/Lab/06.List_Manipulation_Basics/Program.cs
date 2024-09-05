using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

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

                        break;
                    case "Remove":

                        numbers.Remove(int.Parse(inputArr[1]));

                        break;
                    case "RemoveAt":

                        numbers.RemoveAt(int.Parse(inputArr[1]));

                        break;
                    case "Insert":

                        numbers.Insert(int.Parse(inputArr[2]), int.Parse(inputArr[1]));

                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
