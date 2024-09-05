using System;

namespace _01.Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            double price = apronPrice * Math.Ceiling(students * 1.20)
                + eggPrice * 10 * students
                + flourPrice * (students - students / 5);



            if (budget >= price)
            {
                Console.WriteLine($"Items purchased for {price:f2}$.");
            }
            else
            {
                Console.WriteLine($"{price - budget:f2}$ more needed.");
            }
        }
    }
}
