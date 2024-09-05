using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Complete")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Make":

                        switch (tokens[1])
                        {
                            case "Upper":

                                string characterUpper = password[int.Parse(tokens[2])].ToString().ToUpper();

                                password = password.Remove(int.Parse(tokens[2]), 1);

                                password = password.Insert(int.Parse(tokens[2]), characterUpper);

                                Console.WriteLine(password);

                                break;

                            case "Lower":

                                string characterLower = password[int.Parse(tokens[2])].ToString().ToLower();

                                password = password.Remove(int.Parse(tokens[2]), 1);

                                password = password.Insert(int.Parse(tokens[2]), characterLower);

                                Console.WriteLine(password);

                                break;
                        }

                        break;

                    case "Insert":

                        if (int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < password.Length)
                        {
                            password = password.Insert(int.Parse(tokens[1]), tokens[2]);

                            Console.WriteLine(password);
                        }

                        break;

                    case "Replace":

                        int charToBeReplacedValue = char.Parse(tokens[1]) + int.Parse(tokens[2]);
                        char charToBeReplaced = (char)charToBeReplacedValue;

                        password = password.Replace(char.Parse(tokens[1]), charToBeReplaced);

                        Console.WriteLine(password);

                        break;

                    case "Validation":


                        Regex generalRegex = new Regex(@"\w");
                        Regex uppercaseRegex = new Regex(@"[A-Z]");
                        Regex lowercaseRegex = new Regex(@"[a-z]");
                        Regex digitsRegex = new Regex(@"[0-9]");

                        if (password.Length < 8)
                        {
                            Console.WriteLine("Password must be at least 8 characters long!");
                        }
                        if (generalRegex.Matches(password).Count() != password.Length)
                        {
                            Console.WriteLine("Password must consist only of letters, digits and _!");
                        }
                        if(!uppercaseRegex.IsMatch(password))
                        {
                            Console.WriteLine("Password must consist at least one uppercase letter!");
                        }
                        if (!lowercaseRegex.IsMatch(password))
                        {
                            Console.WriteLine("Password must consist at least one lowercase letter!");
                        }
                        if (!digitsRegex.IsMatch(password))
                        {
                            Console.WriteLine("Password must consist at least one digit!");
                        }

                        break;
                }
            }
        }
    }
}
