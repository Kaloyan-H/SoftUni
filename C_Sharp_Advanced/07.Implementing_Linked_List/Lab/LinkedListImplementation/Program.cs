using System;
using System.Security;

namespace LinkedListImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddLast(3);
            list.AddFirst(4);

            list.ForEach(number =>
            {
                Console.WriteLine($"Each number in list: {number}");
            });

            Console.WriteLine(String.Join(", ", list.ToArray()));
        }
    }
}
