using System;

namespace _02.Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            string[] arrayTwo = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arrayOne.Length; i++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    if (arrayOne[i] == arrayTwo[j])
                    {
                        Console.Write(arrayOne[i] + " ");
                    }
                }
            }
        }
    }
}
