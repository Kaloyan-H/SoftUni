using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesAndStudents = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                if (!coursesAndStudents.Keys.Contains(tokens[0]))
                {
                    coursesAndStudents.Add(tokens[0], new List<string>());
                }

                coursesAndStudents[tokens[0]].Add(tokens[1]);
            }

            foreach (var course in coursesAndStudents)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
