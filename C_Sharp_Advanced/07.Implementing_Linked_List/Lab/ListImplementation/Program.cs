using System;

namespace ListImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List list = new List();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(2);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
