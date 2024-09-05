using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Book
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book book = new Book("Test", "Test");
            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            Console.ReadKey();
        }
    }
}
