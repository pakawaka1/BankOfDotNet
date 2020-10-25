using System;

namespace BankOfDotNet
{
    public class AccountLimitException : Exception
    {
        public int numOfAccounts;

        public AccountLimitException(string message, int numOfAccounts) : base(message)
        {
            NumOfAccounts = numOfAccounts;
        }

        public int NumOfAccounts
        {
            get { return numOfAccounts; }
            private set { numOfAccounts = value; }
        }
    }
}
