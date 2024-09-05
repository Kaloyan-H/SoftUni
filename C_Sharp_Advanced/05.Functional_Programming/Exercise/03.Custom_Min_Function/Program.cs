using System;
using System.Linq;

namespace _03.Custom_Min_Function
{
    class Program
    {
        public static int MinMethod(int[] x)
        {
            if (x.Length > 1)
            {
                if (x[0] < MinMethod(x.Skip(1).ToArray()))
                {
                    return x[0];
                }
                else
                {
                    return MinMethod(x.Skip(1).ToArray());
                }
            }
            else
            {
                return x[0];
            }
        }

        static void Main(string[] args)
        {
            Func<string, int> parser = s => int.Parse(s);

            Console.WriteLine(MinMethod(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray()));
        }
    }
}
