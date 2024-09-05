using System;
using System.Linq;

namespace _04.Password_Validator
{
    class Program
    {
        static void CheckPasswordLength(string text, ref int validityIndex)
        {
            if (text.Length < 6 || text.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            else
            {
                validityIndex++;
            }
        }

        static void CheckPasswordContent(string text, ref int validityIndex)
        {
            if (text.Count(lettersAndDigits => "abcdefghijklmnopqrstuvwxyz0123456789".Contains(lettersAndDigits)) < text.Length)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            else
            {
                validityIndex++;
            }
        }

        static void CheckPasswordDigitCount(string text, ref int validityIndex)
        {
            if (text.Count(digits => "0123456789".Contains(digits)) < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            else
            {
                validityIndex++;
            }

        }

        static void Main(string[] args)
        {
            string password = Console.ReadLine().ToLower();
            int validityIndex = 0;

            CheckPasswordLength(password, ref validityIndex);
            CheckPasswordContent(password, ref validityIndex);
            CheckPasswordDigitCount(password, ref validityIndex);

            if (validityIndex == 3)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
