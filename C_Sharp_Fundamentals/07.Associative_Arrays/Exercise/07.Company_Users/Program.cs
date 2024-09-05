using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (!companies.Keys.Contains(tokens[0]))
                {
                    companies.Add(tokens[0], new List<string>());
                }

                if (!companies[tokens[0]].Contains(tokens[1]))
                {
                    companies[tokens[0]].Add(tokens[1]);
                }
            }

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (var ID in company.Value)
                {
                    Console.WriteLine($"-- {ID}");
                }
            }
        }
    }
}
