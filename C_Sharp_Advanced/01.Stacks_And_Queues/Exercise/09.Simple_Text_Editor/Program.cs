using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _09.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> memory = new Stack<string>();
            StringBuilder text = new StringBuilder();
            memory.Push(string.Empty);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split();
                string cmdType = cmdArgs[0];

                if (cmdType == "1")
                {
                    string cmdValue = cmdArgs[1];
                    text.Append(cmdValue);
                    memory.Push(text.ToString());
                }
                else if (cmdType == "2")
                {
                    int charatersToRemove = int.Parse(cmdArgs[1]);
                    text = text.Remove(text.Length - charatersToRemove, charatersToRemove);
                    memory.Push(text.ToString());
                }
                else if (cmdType == "3")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (index >= 0 && index <= text.Length)
                    {
                        Console.WriteLine(text[index - 1]);
                    }
                }
                else if (cmdType == "4")
                {
                    memory.Pop();
                    string previousVersion = memory.Peek();

                    text = new StringBuilder(previousVersion);
                }
            }
        }
    }
}
