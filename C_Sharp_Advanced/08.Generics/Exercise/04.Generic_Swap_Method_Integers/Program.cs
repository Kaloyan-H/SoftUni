using System;

namespace _04.Generic_Swap_Method_Integers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int inputLineCount = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < inputLineCount; i++)
            {
                box.List.Add(int.Parse(Console.ReadLine()));
            }

            string[] cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            box.Swap(int.Parse(cmdArgs[0]), int.Parse(cmdArgs[1]));
            Console.WriteLine(box.ToString());
        }
    }
}
