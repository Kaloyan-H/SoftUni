using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lineOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] lineTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] lineThree = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string> nameAndAddress = new Tuple<string, string>(
                $"{lineOne[0]} {lineOne[1]}",
                lineOne[2]);

            Tuple<string, int> nameAndBeerAmount = new Tuple<string, int>(
                lineTwo[0],
                int.Parse(lineTwo[1]));

            Tuple<int, double> intAndDouble = new Tuple<int, double>(
                int.Parse(lineThree[0]),
                double.Parse(lineThree[1]));

            Console.WriteLine($"{nameAndAddress.Item1} -> {nameAndAddress.Item2}");
            Console.WriteLine($"{nameAndBeerAmount.Item1} -> {nameAndBeerAmount.Item2}");
            Console.WriteLine($"{intAndDouble.Item1} -> {intAndDouble.Item2}");
        }
    }
}
