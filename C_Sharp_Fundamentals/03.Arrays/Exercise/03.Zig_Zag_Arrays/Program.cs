using System;

namespace _03.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string[] arrayOne = new string[lines];
            string[] arrayTwo = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                string[] temp = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (i % 2 == 0)
                {
                    arrayOne[i] = temp[0];
                    arrayTwo[i] = temp[1];
                }
                else
                {
                    arrayOne[i] = temp[1];
                    arrayTwo[i] = temp[0];
                }
            }

            Console.WriteLine($"{string.Join(' ', arrayOne)}\n" +
                $"{string.Join(' ', arrayTwo)}");
        }
    }
}
