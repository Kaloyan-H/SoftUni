using System;

namespace _10.Multiply_Evens_By_Odds
{
    class Program
    {
        static int GetSumOfEvenDigits(int number)
        {
            string tempNumber = number.ToString();
            int result = 0;

            for (int i = 0; i < tempNumber.Length; i++)
            {
                if (int.Parse(tempNumber[i].ToString()) % 2 == 0)
                {
                    result += int.Parse(tempNumber[i].ToString());
                }
            }

            return result;
        }

        static int GetSumOfOddDigits(int number)
        {
            string tempNumber = number.ToString();
            int result = 0;

            for (int i = 0; i < tempNumber.Length; i++)
            {
                if (int.Parse(tempNumber[i].ToString()) % 2 != 0)
                {
                    result += int.Parse(tempNumber[i].ToString());
                }
            }

            return result;
        }

        static int GetMultiplicationOfEvenAndOdd(int even, int odd)
        {
            return even * odd;
        }

        static void Main(string[] args)
        {
            int input = Math.Abs(int.Parse(Console.ReadLine()));

            Console.WriteLine(GetMultiplicationOfEvenAndOdd(GetSumOfOddDigits(input), GetSumOfEvenDigits(input)));
        }
    }
}
