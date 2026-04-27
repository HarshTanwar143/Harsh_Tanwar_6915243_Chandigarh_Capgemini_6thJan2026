using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankChatBot
{

    public interface IBankAccountOperation
    {
        void Deposit(decimal d);
        void Withdraw(decimal d);
        decimal ProcessOperation(string message);
    }

    class BankOperations : IBankAccountOperation
    {
        private decimal balance = 0;

        public void Deposit(decimal d)
        {
            balance += d;
        }

        public void Withdraw(decimal d)
        {
            if (balance >= d)
                balance -= d;
        }

        public decimal ProcessOperation(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return balance;

            string lower = message.ToLower();

            decimal amount = 0;
            var match = Regex.Match(lower, @"\d+");
            if (match.Success)
                amount = Convert.ToDecimal(match.Value);

            if (lower.Contains("deposit") ||
                lower.Contains("invest") ||
                lower.Contains("transfer"))
            {
                Deposit(amount);
            }
            else if (lower.Contains("withdraw") ||
                     lower.Contains("pull"))
            {
                Withdraw(amount);
            }

            return balance;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());
            List<string> inputs = new List<string>();

            for (int i = 0; i < n; i++)
                inputs.Add(Console.ReadLine());

            BankOperations opt = new BankOperations();

            foreach (var item in inputs)
                textWriter.WriteLine(opt.ProcessOperation(item));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
