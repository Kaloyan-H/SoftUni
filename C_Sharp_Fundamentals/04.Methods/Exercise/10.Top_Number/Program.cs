using System;

namespace _10.Top_Number
{
    class Program
    {
        static void DivisibleCheck(int num, ref int validityIndex)
        {
            int sumOfDigits = 0;

            while (num != 0)
            {
                sumOfDigits += num % 10;
                num /= 10;
            }

            if (sumOfDigits % 8 == 0)
            {
                validityIndex++;
            }
        }

        static void OddDigitCheck(int num, ref int validityIndex)
        {
            int temp;

            while (num != 0)
            {
                temp = num % 10;

                if (temp % 2 != 0)
                {
                    validityIndex++;
                    return;
                }

                num /= 10;
            }
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int validityIndex = 0;

            for (int i = 1; i <= number; i++)
            {
                DivisibleCheck(i, ref validityIndex);
                OddDigitCheck(i, ref validityIndex);

                if (validityIndex == 2)
                {
                    Console.WriteLine(i);
                }

                validityIndex = 0;
            }
        }
    }
}
