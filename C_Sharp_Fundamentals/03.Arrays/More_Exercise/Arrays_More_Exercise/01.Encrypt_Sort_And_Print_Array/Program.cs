using System;
using System.Linq;

namespace _01.Encrypt_Sort_And_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] encryptions = new int[n];

            for (int i = 0; i < n; i++)
            {
                int vowelSum = 0;
                int consonantSum = 0;
                int sum = 0;

                string input = Console.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {
                    switch (input[j].ToString().ToLower())
                    {
                        case "a":
                        case "e":
                        case "o":
                        case "u":
                        case "i":
                            vowelSum += input[j];
                            break;
                        default:
                            consonantSum += input[j] / input.Length;
                            break;
                    }
                }

                vowelSum *= input.Length;
                sum = vowelSum + consonantSum;

                encryptions[i] = sum;
            }

            Array.Sort(encryptions);

            Console.WriteLine(string.Join('\n', encryptions));
        }
    }
}
