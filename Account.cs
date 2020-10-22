using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfDotNet
{
    public abstract class Account
        {
            protected Guid accountId;
            protected double balance;

        protected Account(double initialBalance)
        {
            AccountId = Guid.NewGuid();
            Balance = initialBalance;
        }

        public Guid AccountId
        {
            get { return accountId; }
            protected set { accountId = value; }
        }

        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
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
            else
            {
                throw new BankofDotNet.OverdraftException("Insufficient Funds", amount - balance);
            }
        }

        public abstract void Display();
    }

}
