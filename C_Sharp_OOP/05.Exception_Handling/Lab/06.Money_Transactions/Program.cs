using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, decimal> bankAccounts = new Dictionary<int, decimal>();

            string[] accountsArgs = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var accountArgs in accountsArgs)
            {
                string[] accountInfo = accountArgs
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                int accountNumber = int.Parse(accountInfo[0]);
                decimal accountBalance = decimal.Parse(accountInfo[1]);

                bankAccounts.Add(accountNumber, accountBalance);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End") break;

                string[] commandArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];
                int accountNumber = int.Parse(commandArgs[1]);
                decimal moneyAmount = decimal.Parse(commandArgs[2]);

                try
                {
                    if (!bankAccounts.ContainsKey(accountNumber))
                        throw new ArgumentException("Invalid account!");

                    switch (command)
                    {
                        case "Deposit":

                            bankAccounts[accountNumber] += moneyAmount;

                            break;
                        case "Withdraw":

                            if (command == "Withdraw" && bankAccounts[accountNumber] - moneyAmount < 0)
                                throw new ArgumentException("Insufficient balance!");

                            bankAccounts[accountNumber] -= moneyAmount;

                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
