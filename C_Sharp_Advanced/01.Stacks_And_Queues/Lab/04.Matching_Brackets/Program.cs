using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int openingBrIndex = stack.Pop();

                    for (int j = openingBrIndex; j <= i; j++)
                    {
                        Console.Write(expression[j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
