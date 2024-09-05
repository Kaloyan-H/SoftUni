using System;

namespace _02.Grades
{
    class Program
    {
        static void GradeInWords(double n)
        {
            if (n >= 2 && n < 3)
            {
                Console.WriteLine("Fail");
            }
            else if (n < 3.5)
            {
                Console.WriteLine("Poor");
            }
            else if (n < 4.5)
            {
                Console.WriteLine("Good");
            }
            else if (n < 5.5)
            {
                Console.WriteLine("Very good");
            }
            else if (n < 6)
            {
                Console.WriteLine("Excellent");
            }
        }
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            GradeInWords(grade);
        }
    }
}
