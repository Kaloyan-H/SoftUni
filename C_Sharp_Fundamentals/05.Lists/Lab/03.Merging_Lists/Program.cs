using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> list2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> result = new List<double>();

            int resultLength = list1.Count + list2.Count;


            while (list1.Count > 0 || list2.Count > 0)
            {
                if (list1.Count > 0)
                {
                    result.Add(list1[0]);
                    list1.RemoveAt(0);
                }

                if (list2.Count > 0)
                {
                    result.Add(list2[0]);
                    list2.RemoveAt(0);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
