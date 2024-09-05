using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsAndGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsAndGrades.Keys.Contains(name))
                {
                    studentsAndGrades.Add(name, new List<double>());
                }

                studentsAndGrades[name].Add(grade);
            }

            foreach (var student in studentsAndGrades)
            {
                if (student.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }
        }
    }
}
