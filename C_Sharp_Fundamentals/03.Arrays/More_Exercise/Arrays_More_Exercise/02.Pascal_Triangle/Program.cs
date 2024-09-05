using System;

namespace _02.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] array = new string[60];
            array[0] = "1";

            for (int i = 0; i < n; i++)
            {
                string[] tempArray = array;

                for (int j = 0; j <= i; j++)
                {
                    
                }

                Console.WriteLine(string.Join(' ', array));
            }
        }
    }
}
