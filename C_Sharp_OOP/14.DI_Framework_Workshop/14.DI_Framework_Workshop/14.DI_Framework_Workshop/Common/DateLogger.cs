using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DI_Framework_Workshop.Common
{
    using Contracts;

    public class DateLogger : ILogger
    {
        private readonly DateTime date;

        public DateLogger(int day, int month, int year)
        {
            date = new DateTime(day, month, year);
        }

        public void Log(string message)
        {
            Console.WriteLine($"DATE: {date.ToString("dd/MM/yyyy")}");
        }
    }
}
