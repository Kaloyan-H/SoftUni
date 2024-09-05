using System;

namespace _11.Tri_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isEqualOrLonger = (s, n) =>
            {
                int sum = 0;

                foreach (var item in s)
                {
                    sum += item;
                }

                return sum >= n;
            };

            Func<string[], Func<string, int, bool>, string> firstNameEqualOrLonger = (arr, ieol) =>
            {
                foreach (var item in arr)
                {
                    if (ieol(item, number))
                    {
                        return item;
                    }
                }
                return string.Empty;
            };

            Console.WriteLine(firstNameEqualOrLonger(names, isEqualOrLonger));
        }
    }
}
