namespace UniversityCompetition.Models
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using Utilities.Messages;
    using System.Linq;

    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;

        public University
            (int universityId,
            string universityName,
            string category,
            int capacity,
            ICollection<int> requiredSubjects)
        {
            this.Id = universityId;
            this.Name = universityName;
            this.Category = category;
            this.Capacity = capacity;
            this.requiredSubjects = requiredSubjects.ToList();
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
        public string Category
        {
            get { return category; }
            private set
            {
                switch (value)
                {
                    case "Technical":
                    case "Economical":
                    case "Humanity":
                        category = value;
                        break;
                    default:
                        throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
            }
        }
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                capacity = value;
            }
        }
        public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects.AsReadOnly();
    }
}
