using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Generic_Box_Of_String
{
    public class Box<T>
    {
        private List<T> list = new List<T>();

        public Box() { }

        public List<T> List
        { 
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
