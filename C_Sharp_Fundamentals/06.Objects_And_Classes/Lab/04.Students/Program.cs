using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Student> studentList = new List<Student>();

            while (input[0] != "end")
            {
                studentList.Add(new Student
                {
                    FirstName = input[0],
                    LastName = input[1],
                    Age = int.Parse(input[2]),
                    HomeTown = input[3]
                });

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string city = Console.ReadLine();

            List<Student> filteredStudentList = studentList
                .Where(s => s.HomeTown == city)
                .ToList();

            foreach (Student student in filteredStudentList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
