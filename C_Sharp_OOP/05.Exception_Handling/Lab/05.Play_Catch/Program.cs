using System;
using System.Linq;

namespace _05.Play_Catch
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int exceptionsCaught = 0;

            while (exceptionsCaught < 3)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    RunCommand(commandArgs, numbers);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    exceptionsCaught++;
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        public static void RunCommand(string[] commandArgs, int[] numbers)
        {
            string command = commandArgs[0];

            switch (command)
            {
                case "Replace":

                    try
                    {
                        numbers[int.Parse(commandArgs[1])] = int.Parse(commandArgs[2]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException("The index does not exist!");
                    }
                    catch (FormatException)
                    {
                        throw new ArgumentException("The variable is not in the correct format!");
                    }

                    break;
                case "Print":

                    try
                    {
                        int startIndex = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);

                        if (startIndex < 0 || endIndex > numbers.Length - 1)
                        {
                            throw new IndexOutOfRangeException();
                        }

                        Console.WriteLine(String.Join(", ", numbers
                            .Skip(startIndex)
                            .Take(endIndex - startIndex + 1)));
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException("The index does not exist!");
                    }
                    catch (FormatException)
                    {
                        throw new ArgumentException("The variable is not in the correct format!");
                    }

                    break;
                case "Show":

                    try
                    {
                        Console.WriteLine(numbers[int.Parse(commandArgs[1])]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException("The index does not exist!");
                    }
                    catch (FormatException)
                    {
                        throw new ArgumentException("The variable is not in the correct format!");
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }
    }
}
