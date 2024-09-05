using System;

namespace _01.Day_Of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] weekdays =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (n >= 1 && n <= 7)
            {
                Console.WriteLine(weekdays[n - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
