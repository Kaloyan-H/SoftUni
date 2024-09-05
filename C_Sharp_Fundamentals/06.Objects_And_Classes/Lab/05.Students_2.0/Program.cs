using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students_2._0
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
        static bool DoesStudentExist(List<Student> studentList, string firstName, string lastName)
        {
            foreach (Student student in studentList)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindAndOverwrite(List<Student> studentList, string firstName, string lastName, int age, string homeTown)
        {
            foreach (Student student in studentList)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    student.Age = age;
                    student.HomeTown = homeTown;
                }
            }
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Student> studentList = new List<Student>();

            while (input[0] != "end")
            {
                if (DoesStudentExist(studentList, input[0], input[1]))
                {
                    FindAndOverwrite(studentList, input[0], input[1], int.Parse(input[2]), input[3]);
                }
                else
                {
                    studentList.Add(new Student
                    {
                        FirstName = input[0],
                        LastName = input[1],
                        Age = int.Parse(input[2]),
                        HomeTown = input[3]
                    });
                }

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
