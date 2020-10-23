using System;
using System.Collections.Generic;
using System.Text;

namespace BankofDotNet
{
    public class Customer
    {
        private const int MAXACCOUNTS = 2;
        private Guid customerId;
        private string firstName;
        private string lastName;
        private List<BankOfDotNet.Account> accounts;

        private Customer(string firstName, string lastName)
        {
            customerId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            accounts = new List<BankOfDotNet.Account>(MAXACCOUNTS);
        }

        public Guid CustomerId
        {
            get { return customerId; }
            private set { customerId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }

        public int NumOfAccounts
        {
            get { return accounts.Count; }
        }

        public void AddAccount(BankOfDotNet.Account account)
        {
            if (accounts.Count < MAXACCOUNTS)
            {
                accounts.Add(account);
            }
            else
            {
                throw new AccountLimitException("Maximum number of accounts reached", accounts.Count);
            }
        }

        public List<BankOfDotNet.Account> GetAccounts()
        {
            return accounts;
        }

        public ITransferable GetFirstTransferableAccount()
        {
            foreach(BankOfDotNet.Account account in accounts)
            {
                if(account is ITransferable a)
                {
                    return a;
                }
            }
            return null;
        }

        }


    }
