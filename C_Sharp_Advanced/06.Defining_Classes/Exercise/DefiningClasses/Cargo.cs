using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        private string type;
        private int weight;

        public Cargo() { }
        public Cargo(string type, int weight)
        {
            this.type = type;
            this.weight = weight;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
