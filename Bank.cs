using System;
using System.Collections.Generic;
using System.Linq;

namespace BankOfDotNet
{
    public class Bank
    {
        private const int MAXCUSTOMERS = 10;
        private List<Customer> customers;

        //private object customer;
        public Bank(string bankName)
        {
            BankName = bankName;
            customers = new List<Customer>(MAXCUSTOMERS);
        }

        public string BankName
        {
            get;
            set;
        }

        public int NumOfCustomers
        {
            get { return customers.Count; }
        }

        public void AddCustomer(string firstName, string lastName)
        {
            if (customers.Count < MAXCUSTOMERS)
            {
                customers.Add(new Customer(firstName, lastName));

            }
        }

        public Customer GetCustomer(string firstName, string lastName)
        {
            return customers.Where(c => c.FirstName == firstName && c.LastName == lastName).First();

        }

        public override string ToString()
        {
            return $"Bank Name: {BankName}, Total Customers: {NumOfCustomers}";
        }

        public void GenerateReport()
        {
            Console.WriteLine("Customers Report");
            Console.WriteLine("----------------");

            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Customer {customer.LastName}, {customer.FirstName}");
                foreach (Account account in customer.GetAccounts())

                {
                    if (account is CheckingAccount)
                    {
                        Console.WriteLine("Checking Account");
                    }
                    else if (account is SavingsAccount)
                    {
                        Console.WriteLine("SavingsAccount");
                    }
                    else
                    {
                        Console.WriteLine("Unknown Account Type");
                    }


                    Console.WriteLine($"Current Balance: {account.Balance}");


                }
            }

        }
    }
}