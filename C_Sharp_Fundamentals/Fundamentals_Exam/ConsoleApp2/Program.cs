using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]");

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();

                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }

                string command = regex.Match(input).Groups[1].ToString();
                string message = regex.Match(input).Groups[2].ToString();

                List<int> messageToNumbers = new List<int>();

                foreach (var character in message)
                {
                    messageToNumbers.Add((int)character);
                }

                Console.WriteLine($"{command}: {string.Join(' ', messageToNumbers)}");
            }
        }
    }
}
