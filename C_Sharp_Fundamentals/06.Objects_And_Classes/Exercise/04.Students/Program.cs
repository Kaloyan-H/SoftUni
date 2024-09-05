using System;
using System.Linq;

namespace _04.Students
{
    class Student
    {
        public Student() { }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Student[] students = new Student[studentsCount];

            for (int i = 0; i < students.Length; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                students[i] = new Student(tokens[0], tokens[1], double.Parse(tokens[2]));
            }

            Student[] studentsSortedByGrade = students
                .OrderByDescending(student => student.Grade)
                .ToArray();

            foreach (var student in studentsSortedByGrade)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
