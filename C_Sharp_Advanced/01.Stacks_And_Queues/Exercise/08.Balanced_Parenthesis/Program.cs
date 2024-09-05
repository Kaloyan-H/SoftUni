using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '{':
                    case '[':
                    case '(':

                        stack.Push(input[i]);

                        break;

                    case '}':

                        if (stack.Count > 0 && stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;

                    case ']':

                        if (stack.Count > 0 && stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;

                    case ')':

                        if (stack.Count > 0 && stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
