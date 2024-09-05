using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Generic_Swap_Method_Strings
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
        public void Swap(int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
