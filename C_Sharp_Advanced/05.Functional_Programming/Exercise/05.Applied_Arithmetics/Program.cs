using System;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        public static void Operation(int[] array, Func<int, int> operation, int index = 0)
        {
            if (array.Length > 0)
            {
                array[index] = operation(array[index]);
            }

            if (index < array.Length - 1)
            {
                Operation(array, operation, index + 1);
            }

            //Jigachad code^

            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = operation(array[i]);
            //}

        }

        static void Main(string[] args)
        {
            Func<int, int> add = i => i + 1;
            Func<int, int> multiply = i => i * 2;
            Func<int, int> subtract = i => i - 1;

            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    return;
                }

                switch (input)
                {
                    case "add":
                        Operation(array, add);
                        break;

                    case "multiply":
                        Operation(array, multiply);
                        break;

                    case "subtract":
                        Operation(array, subtract);
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", array));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
