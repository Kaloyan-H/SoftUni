using System;

namespace _03.Generic_Swap_Method_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputLineCount = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < inputLineCount; i++)
            {
                box.List.Add(Console.ReadLine());
            }

            string[] cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            box.Swap(int.Parse(cmdArgs[0]), int.Parse(cmdArgs[1]));
            Console.WriteLine(box.ToString()); 
        }
    }
}
