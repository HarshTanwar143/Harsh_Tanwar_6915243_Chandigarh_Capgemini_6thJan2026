using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class BankAccountUtil
    {
        public decimal Balance { get; private set; }

        public BankAccountUtil(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
        }
    }
}
