using System;

namespace _04.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                string temp = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
