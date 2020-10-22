using System;
using System.Collections.Generic;
using System.Text;
using BankOfDotNet;

namespace BankofDotNet
{
    public class SavingsAccount : Account
    {
        private double interestRate;

        public SavingsAccount(double initialBalance, double interestRate) : base(initialBalance) 
        {
            this.interestRate = interestRate;
        }

        public override void Display()
        {
            Console.WriteLine($"Savings Account ID: {accountId}");
            Console.WriteLine($"Savings Account Balance: {balance}");
            Console.WriteLine($"Savings Accont Overdraft Balance: {interestRate}");
        }

        public void Transfer(Account to, double amount)
        {
            this.Withdraw(amount);
            to.Deposit(amount); 
        }
    }
}
