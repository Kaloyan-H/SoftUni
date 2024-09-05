using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                char[] reversed = input.ToCharArray();

                Array.Reverse(reversed);

                string reversedString = new string(reversed);

                Console.WriteLine($"{input} = {reversedString}");
            }
        }
    }
}
