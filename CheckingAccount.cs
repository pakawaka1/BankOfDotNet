using System;
using System.Collections.Generic;
using System.Text;

namespace BankofDotNet
{
    public class CheckingAccount : BankOfDotNet.Account
    {
        private double overdraftBalance;

        public CheckingAccount(double initialBalance) : this(initialBalance, 0.0)
        

        {
        }

        public CheckingAccount( double initialBalance, double overdraftBalance) : base(initialBalance)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"Checking Account ID: {accountId}");
            Console.WriteLine($"Checking Account Balance: {balance}");
            Console.WriteLine($"Checking Accont Overdraft Balance: {overdraftBalance}");

        }

        public override void Withdraw(double amount)
        {
            if (balance < amount)
            {
                double overdraftAmountRequired = amount - balance;
                if (overdraftBalance < overdraftAmountRequired) {
                    throw new OverdraftException("Insufficient funds using Overdraft Protection", overdraftAmountRequired);
                }
                else
                {
                    balance = 0.0;
                    overdraftBalance -= overdraftAmountRequired;
                }
            }
            else
            {
                balance -= amount;
            }

            }
    
        }

    }

