using System;
using System.Text;

namespace _09.Palindrome_Integers
{
    class Program
    {
        static bool IsItAPalindrome(int number)
        {
            string temp = number.ToString();
            StringBuilder firstHalf = new StringBuilder();
            StringBuilder secondHalf = new StringBuilder();

            for (int i = 0; i < temp.Length / 2; i++)
            {
                firstHalf.Append(temp[i]);
            }

            if (temp.Length % 2 != 0)
            {
                for (int i = temp.Length - 1; i > temp.Length / 2; i--)
                {
                    secondHalf.Append(temp[i]);
                }
            }
            else
            {
                for (int i = temp.Length - 1; i >= temp.Length / 2; i--)
                {
                    secondHalf.Append(temp[i]);
                }
            }

            if (firstHalf.ToString() == secondHalf.ToString())
            {
                return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                int number = int.Parse(input);

                Console.WriteLine(IsItAPalindrome(number).ToString().ToLower());

                input = Console.ReadLine();
            }
        }
    }
}
