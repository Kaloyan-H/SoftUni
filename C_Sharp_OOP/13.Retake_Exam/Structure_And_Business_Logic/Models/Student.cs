namespace UniversityCompetition.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Utilities.Messages;

    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;

        private Student()
        {
            coveredExams = new List<int>();
        }
        public Student(int studentId, string firstName, string lastName)
            : this()
        {
            this.Id = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        }
        public IReadOnlyCollection<int> CoveredExams => coveredExams.AsReadOnly();
        public IUniversity University
        {
            get { return university; }
            private set { university = value; }
        }

        public void CoverExam(ISubject subject)
        {
            this.coveredExams.Add(subject.Id);
        }
        public void JoinUniversity(IUniversity university)
        {
            this.University = university;
        }
    }
}
