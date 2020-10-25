using System;
using System.Linq;

namespace BankOfDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create Bank
                Bank bank = new Bank("BankOfDotNet");
                Customer customer;
                Account account;

                try
                { // create bank customers////////////////////////////////////////////////////////////////////////////////////////////
                    bank.AddCustomer("Jane", "Doe");
                    bank.AddCustomer("John", "Doe");
                    Console.WriteLine(bank.ToString());

                }
                catch (CustomerLimitException cle)
                {
                    Console.WriteLine($"Customer Limit Exception {cle.Message} ");
                    Console.WriteLine($"Customer Count: {cle.NumOfCustomers}");
                }

                try
                {
                    // Create Customer Account////////////////////////////////////////////////////////////////////////////////////////////
                    customer = bank.GetCustomer("Jane", "Doe");
                    customer.AddAccount(new CheckingAccount(500.00, 500.00));
                    customer.AddAccount(new SavingsAccount(1500.00, 0.01));

                    customer = bank.GetCustomer("John", "Doe");
                    customer.AddAccount(
                        bank.GetCustomer("Jane", "Doe")
                        .GetAccounts().Where(a => a.GetType() == typeof(CheckingAccount)).First());

                }
                catch (AccountLimitException ale)
                {
                    Console.WriteLine($"Customer Limit Exception {ale.Message} ");
                    Console.WriteLine($"Customer Count: {ale.NumOfAccounts}");
                }

                bank.GenerateReport();

                // Jane's Transactions

                Console.WriteLine();
                Console.WriteLine("Getting Jane Doe's Checking Account having Overdraft Protection");
                customer = bank.GetCustomer("Jane", "Doe");
                account = customer.GetAccounts()
                    .Where(a => a.GetType() == typeof(CheckingAccount)).First();

                try
                {
                    account.Withdraw(155.00);
                    account.Deposit(23.50);
                    account.Withdraw(48.75);
                    account.Withdraw(450.00);
                }
                catch (OverdraftException odex)
                {
                    Console.WriteLine($"Overdraft Exception: {odex.Message}");
                    Console.WriteLine($"Overdraft Deficit: {odex.DeficitAmount}") ;
                }


                // John'sJs Transactions

                Console.WriteLine();
                Console.WriteLine("Getting John Doe's Checking Account having Overdraft Protection");
                customer = bank.GetCustomer("John", "Doe");
                account = customer.GetAccounts()
                    .Where(a => a.GetType() == typeof(CheckingAccount)).First();

                try
                {
                    account.Deposit(155.00);
                    account.Withdraw(755.00);
                }
                catch (OverdraftException odex)
                {
                    Console.WriteLine($"Overdraft Exception: {odex.Message}");
                    Console.WriteLine($"Overdraft Deficit: {odex.DeficitAmount}");
                }
                finally
                {
                    Console.WriteLine($"Customer { customer.LastName}, {customer.FirstName} account details");
                    account.Display();
                }



                // Jane's Transactions

                Console.WriteLine();
                Console.WriteLine("Getting Jane Doe's First Transferable Account");
                customer = bank.GetCustomer("Jane", "Doe");
                ITransferable transferrableAccount = customer.GetFirstTransferableAccount();

                
                try
                {
                    transferrableAccount.Transfer(account, 1000.00);
                }
                catch (OverdraftException odex)
                {
                    Console.WriteLine($"Overdraft Exception: {odex.Message}");
                    Console.WriteLine($"Overdraft Deficit: {odex.DeficitAmount}");
                }
                finally
                {
                    Console.WriteLine($"Customer { customer.LastName}, {customer.FirstName} account details");
                    account.Display();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bank Exception: {ex.Message}");
            }
        }
    }
}
