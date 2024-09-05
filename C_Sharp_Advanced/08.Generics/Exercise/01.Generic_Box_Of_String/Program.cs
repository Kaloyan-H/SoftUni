using System;

namespace _01.Generic_Box_Of_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < count; i++)
            {
                box.List.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(box.ToString());
        }
    }
}
