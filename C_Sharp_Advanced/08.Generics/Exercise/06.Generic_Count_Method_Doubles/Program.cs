using System;

namespace _06.Generic_Count_Method_Doubles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                box.List.Add(double.Parse(input));
            }

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(box.GreaterElements(double.Parse(itemToCompare)));
        }
    }
}
