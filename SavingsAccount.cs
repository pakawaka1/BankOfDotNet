using System;

namespace BankOfDotNet
{
    public class SavingsAccount : Account
    {
        public double interestRate;

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

        public void Transfer(SavingsAccount to, double amount)
        {
            this.Withdraw(amount);
            to.Deposit(amount); 
        }
    }
}
