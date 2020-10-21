using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfDotNet
{
    public abstract class Account
        {
            protected Guid accountId;
            protected double balance;

        protected Account(double initialBalance);
        {
            AccountId = Guid.newGuid();
            Balance = initialBalance;
        }

        public Guid AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public virtual void Deposit(double amount)
        {
            balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
        }

        public abstract void Display();
    }
}
