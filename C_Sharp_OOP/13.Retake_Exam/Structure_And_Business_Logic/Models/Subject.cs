namespace UniversityCompetition.Models
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;

        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            this.Id = subjectId;
            this.Name = subjectName;
            this.Rate = subjectRate;
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public double Rate
        {
            get { return rate; }
            private set { rate = value; }
        }
    }
}
