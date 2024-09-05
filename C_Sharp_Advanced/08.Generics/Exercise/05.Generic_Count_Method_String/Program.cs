using System;
using System.Collections.Generic;

namespace _05.Generic_Count_Method_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                box.List.Add(input);
            }

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(box.GreaterElements(itemToCompare));
        }
    }
}
