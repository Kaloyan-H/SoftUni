namespace UniversityCompetition.Core
{
    using Contracts;
    using System.Collections.Generic;
    using Repositories;
    using UniversityCompetition.Models.Contracts;
    using System;
    using System.Reflection;
    using System.Linq;
    using Models;
    using Utilities.Messages;
    using System.Text;

    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(students.Models.Count + 1, firstName, lastName);

            students.AddModel(student);

            return string
                .Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Subject).IsAssignableFrom(t) && t.Name.StartsWith(subjectType))
                .FirstOrDefault();

            if (type == null)
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.Models.Any(s => s.Name == subjectName))
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject = (ISubject)Activator
                .CreateInstance(type, new object[] { subjects.Models.Count + 1, subjectName });

            subjects.AddModel(subject);

            return string
                .Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.Models.Any(u => u.Name == universityName))
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectsIds = requiredSubjects
                .Select(s => subjects.Models.FirstOrDefault(m => m.Name == s).Id)
                .ToList();

            IUniversity university =
                new University(
                    universities.Models.Count + 1,
                    universityName,
                    category,
                    capacity,
                    requiredSubjectsIds);

            universities.AddModel(university);

            return string
                .Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] args = studentName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = args[0];
            string lastName = args[1];

            IStudent student = students.Models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            IUniversity university = universities.Models.FirstOrDefault(u => u.Name == universityName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            bool studentHasCoveredAllRequiredExams = true;

            foreach (int examId in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(examId))
                {
                    studentHasCoveredAllRequiredExams = false;
                    break;
                }
            }

            if (!studentHasCoveredAllRequiredExams)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            if (student.University != null)
            {
                if (student.University.Name == universityName)
                {
                    return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
                }
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!students.Models.Any(s => s.Id == studentId))
            {
                return OutputMessages.InvalidStudentId;
            }
            if (!subjects.Models.Any(s => s.Id == subjectId))
            {
                return OutputMessages.InvalidSubjectId;
            }

            IStudent student = students.Models.FirstOrDefault(s => s.Id == studentId);
            ISubject subject = subjects.Models.FirstOrDefault(s => s.Id == subjectId);

            if (student.CoveredExams.Any(id => id == subjectId))
            {
                return string
                    .Format(OutputMessages.StudentAlreadyCoveredThatExam,
                    student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam,
                student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.Models.FirstOrDefault(u => u.Id == universityId);

            int studentsCount = 0;

            foreach (var student in students.Models)
            {
                if (student.University == university)
                {
                    studentsCount++;
                }
            }

            int capacityLeft = university.Capacity - studentsCount;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {capacityLeft}");

            return sb.ToString().TrimEnd();
        }
    }
}
