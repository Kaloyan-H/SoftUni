using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DI_Framework_Workshop.Common
{
    using Contracts;

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"logging {message}");
        }
    }
}
