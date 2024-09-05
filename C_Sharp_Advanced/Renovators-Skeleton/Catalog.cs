using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators = new List<Renovator>();
        private string name;
        private int neededRenovators;
        private string project;

        public Catalog() { }
        public Catalog(string name, int neededRenovators, string project)
        {
            this.name = name;
            this.neededRenovators = neededRenovators;
            this.project = project;
        }

        public List<Renovator> Renovators
        {
            get { return renovators; }
            set { renovators = value; }
        }
        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }
        public string Project
        {
            get { return project; }
            set { project = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Count
        {
            get { return renovators.Count; }
        }

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null
                || renovator.Name == string.Empty
                || renovator.Type == null
                || renovator.Type == string.Empty)
            {
                return "Invalid renovator's information.";
            }
            else if (neededRenovators == 0)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            neededRenovators--;
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name) => renovators.Remove(renovators.Find(x => x.Name == name));
        public int RemoveRenovatorBySpecialty(string type) => renovators.RemoveAll(x => x.Type == type);
        public Renovator HireRenovator(string name)
        {
            //var renovatorFound = renovators.Find(x => x.Name == name);
            //if (renovatorFound != null)
            //{
            //    renovatorFound.Hired = true;
            //}
            //return renovatorFound;
            renovators.Where(x => x.Name == name).Select(x => x.Hired = true);
            return renovators.Find(x => x.Name == name);
        }
        public List<Renovator> PayRenovators(int days) => renovators.Where(x => x.Days >= days).ToList();
        public string Report()
        {
            return $"Renovators available for Project {project}:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, renovators.Where(x => x.Hired == false))}";
        }
    }
}
